    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Disruptor;
    using Disruptor.Dsl;
    
    namespace DisruptorTest
    {
        public sealed class ValueEntry
        {
            public int Value { get; set; }
    
            public ValueEntry()
            {
             //   Console.WriteLine("New ValueEntry created");
            }
        }
    
        class Program
        {
            public const int length = 1000000;
            public static Stopwatch sw;
    
            private static readonly Random _random = new Random();
            private static readonly int _ringSize = 1024;  // Must be multiple of 2
    
            static void Main(string[] args)
            {
                sw = Stopwatch.StartNew();
    
                var disruptor = new Disruptor.Dsl.Disruptor<ValueEntry>(() => new ValueEntry(), _ringSize, TaskScheduler.Default);
                var ringBuffer = disruptor.Start();
    
                for (int i = 0; i < length; i++)
                {
                    var valueToSet = i;
                    long sequenceNo = ringBuffer.Next();
    
                    ValueEntry entry = ringBuffer[sequenceNo];
    
                    entry.Value = valueToSet;
    
                    ringBuffer.Publish(sequenceNo);
    
                    //Console.WriteLine("Published entry {0}, value {1}", sequenceNo, entry.Value);
    
                    //Thread.Sleep(1000);
                }
    
                var elapsed = sw.Elapsed.Miliseconds();
                // wait until all events are delivered
                Thread.Sleep(10000);
    
                double average = /(double)length;
                Console.WriteLine("average = " + average);
            }
        }
    }
