    using System;
    using System.Threading.Tasks;
    using Disruptor;
    using Disruptor.Dsl;
    
    namespace DisruptorTest
    {
        public sealed class ValueEntry
        {
            public long Value { get; set; }
        }
    
        public class MyHandler : IEventHandler<ValueEntry>
        {
            private static int _consumers = 0;
            private readonly int _ordinal;
    
            public MyHandler()
            {
                this._ordinal = _consumers++;
            }
    
            public void OnNext(ValueEntry data, long sequence, bool endOfBatch)
            {
                if ((sequence % _consumers) == _ordinal)
                    Console.WriteLine("Event handled: Value = {0}, event {1} processed by {2}", data.Value, sequence, _ordinal);
                else
                    Console.WriteLine("Event {0} rejected by {1}", sequence, _ordinal);                     
            }
        }
    
        class Program
        {
            private static readonly Random _random = new Random();
            private const int SIZE = 16;  // Must be multiple of 2
    		private const int WORKERS = 4; 
    
            static void Main()
            {
                var disruptor = new Disruptor.Dsl.Disruptor<ValueEntry>(() => new ValueEntry(), SIZE, TaskScheduler.Default);
                for (int i=0; i < WORKERS; i++)
                    disruptor.HandleEventsWith(new MyHandler());
    			var ringBuffer = disruptor.Start();
    
                while (true)
                {
                    long sequenceNo = ringBuffer.Next();
                    ringBuffer[sequenceNo].Value =  _random.Next();;
                    ringBuffer.Publish(sequenceNo);
                    Console.WriteLine("Published entry {0}, value {1}", sequenceNo, ringBuffer[sequenceNo].Value);
                    Console.ReadKey();
                }
            }
        }
    }
