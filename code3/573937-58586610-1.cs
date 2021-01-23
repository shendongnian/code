    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Disruptor;
    using Disruptor.Dsl;
    using NUnit.Framework;
    namespace DisruptorTest.Ds
    {
        public sealed class ValueEntry
        {
            internal int Id { get; set; }
        }
        class MyHandler : IEventHandler<ValueEntry>
        {
            public void OnEvent(ValueEntry data, long sequence, bool endOfBatch)
            {
            }
        }
        [TestFixture]
        public class DisruptorPerformanceTest
        {
            private volatile bool collectionAddEnded;
            private int runCount = 1000000;
            private const int RingSize = 1024;
            [TestCase()]
            public async Task TestAll()
            {
                DisruptorTest();
                await BlockingCollectionTest();
            }
            [TestCase()]
            public async Task BlockingCollectionTest()
            {
                var sw = new Stopwatch();
                BlockingCollection<ValueEntry> dataItems = new BlockingCollection<ValueEntry>(RingSize);
                sw.Start();
                // A simple blocking consumer with no cancellation.
                var task = Task.Factory.StartNew(() =>
                {
                    // while (!ended && !dataItems.IsCompleted)
                    while (!collectionAddEnded)
                    {
                        ValueEntry ve = dataItems.Take();
                    }
                }, TaskCreationOptions.LongRunning);
                for (int i = 0; i < runCount; i++)
                {
                    ValueEntry entry = new ValueEntry();
                    entry.Id = i;
                    dataItems.Add(entry);
                }
                collectionAddEnded = true;
                await task;
                sw.Stop();
                Console.WriteLine($"BlockingCollectionTest Time:{sw.ElapsedMilliseconds}");
            }
            [TestCase()]
            public void DisruptorTest()
            {
                var disruptor =
                    new Disruptor.Dsl.Disruptor<ValueEntry>(() => new ValueEntry(), RingSize, TaskScheduler.Default,
                        ProducerType.Single, new BlockingWaitStrategy());
                disruptor.HandleEventsWith(new MyHandler());
                var _ringBuffer = disruptor.Start();
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                for (int i = 0; i < runCount; i++)
                {
                    long sequenceNo = _ringBuffer.Next();
                    _ringBuffer[sequenceNo].Id = 0;
                    _ringBuffer.Publish(sequenceNo);
                }
                disruptor.Shutdown();
                sw.Stop();
                Console.WriteLine($"DisruptorTest Time:{sw.ElapsedMilliseconds}");
            }
        }
    }
