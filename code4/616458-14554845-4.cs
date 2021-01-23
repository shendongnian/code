        public class ProducerConsumer<T> {
    
            public struct Message {
                public T Data;
            }
    
            private readonly ThreadRunner _producer;
            private readonly ThreadRunner _consumer;
    
            public ProducerConsumer(Func<T> produce, Action<T> consume) {
                var q = new BlockingCollection<Message>();
                _producer = new Producer(produce,q);
                _consumer = new Consumer(consume,q);
            }
    
            public void Start() {
                _producer.Run();
                _consumer.Run();
            }
    
            public void Stop() {
                _producer.Stop();
                _consumer.Stop();
            }
    
            private class Producer : ThreadRunner {
    
                public Producer(Func<T> produce, BlockingCollection<Message> q) : base(q) {
                    _produce = produce;
                }
    
                private readonly Func<T> _produce;
    
                public override void Worker() {
                    try {
                        while (KeepRunning) {
                            var item = _produce();
                            MessageQ.TryAdd(new Message{Data = item});
                        }
                    }
                    catch (ThreadInterruptedException) {
                        WasInterrupted = true;
                    }
                }
            }
    
            public abstract class ThreadRunner {
    
                protected readonly BlockingCollection<Message> MessageQ;
    
                protected ThreadRunner(BlockingCollection<Message> q) {
                    MessageQ = q;
                }
    
                protected Thread Runner;
                protected bool KeepRunning = true;
    
                public bool WasInterrupted;
    
                public abstract void Worker();
    
                public void Run() {
                    Runner = new Thread(Worker);
                    Runner.Start();
                }
    
                public void Stop() {
                    KeepRunning = false;
                    Runner.Interrupt();
                    Runner.Join();
                }
    
            }
    
            class Consumer : ThreadRunner {
    
                private readonly Action<T> _consume;
    
                public Consumer(Action<T> consume,BlockingCollection<Message> q) : base(q) {
                    _consume = consume;
                }
    
                public override void Worker() {
                    try {
                        while (KeepRunning) {
                            Message message;
                            if (MessageQ.TryTake(out message, TimeSpan.FromMilliseconds(100))) {
                                _consume(message.Data);
                            }
                            else {
                                //There's nothing in the Q so I have some spare time...
                                //Excellent moment to update my statisics or update some history to logfiles
                                //for now we sleep:
                                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            }
                        }
                    }
                    catch (ThreadInterruptedException) {
                        WasInterrupted = true;
                    }
                }
            }
        }
    
    }
