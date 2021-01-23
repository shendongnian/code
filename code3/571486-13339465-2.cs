    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Disruptor;
    using Disruptor.Dsl;
    
    namespace DisruptorTest
    {
        public sealed class ValueEntry
        {
            public long Value { get; set; }
    
            public ValueEntry()
            {
                Console.WriteLine("New ValueEntry created");
            }
        }
    
        public class MyHandler : IEventHandler<ValueEntry>
        {
    	    private readonly long _ordinal;
    	    private readonly long _numberOfConsumers;
    		
    	    public MyHandler(long numberOfConsumers, long ordinal)
    	    {
    	        this._ordinal = ordinal;
    	        this._numberOfConsumers = numberOfConsumers;
    	    }
    		
            public void OnNext(ValueEntry data, long sequence, bool endOfBatch)
            {
    	        if ((sequence % _numberOfConsumers) == _ordinal)
                	Console.WriteLine("Event handled: Value = {0}, event {1} processed by {2}", data.Value, sequence, _ordinal);
    			else
    				Console.WriteLine("Event {0} rejected by {1}", sequence, _ordinal);     				
            }
        }
    
        class Program
        {
            private static readonly Random _random = new Random();
            private static readonly int _ringSize = 4;  // Must be multiple of 2
    
            static void Main(string[] args)
            {
                var disruptor = new Disruptor.Dsl.Disruptor<ValueEntry>(() => new ValueEntry(), _ringSize, TaskScheduler.Default);
    			
    			for (int i=0; i < _ringSize; i++)
                	disruptor.HandleEventsWith(new MyHandler(_ringSize, i));
    
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
