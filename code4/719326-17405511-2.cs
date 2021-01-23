    public sealed class DataFlowOptimizer<T>
    {
        private readonly IEnumerable<T> _collection;
        private RateRecord bestRate = RateRecord.Default;
        private uint batchLength = 1;
        
        private struct RateRecord
        {
            public static RateRecord Default = new RateRecord { Length = 1, ElapsedTicks = 0 };
            private float _rate;
        
            public int Length { get; set; }
            public long ElapsedTicks { get; set; }
            public float Rate
            {
                get
                {
                    if(_rate == default(float) && ElapsedTicks > 0)
                    {
                        _rate = ((float)Length) / ElapsedTicks;
                    }
                    
                    return _rate;
                }
            }
        }
        
        public DataFlowOptimizer(IEnumerable<T> collection)
        {
            _collection = collection;
        }
        
        public int BatchLength { get { return (int)batchLength; } }
        public float Rate { get { return bestRate.Rate; } }
        
        public IEnumerable<IList<T>> GetBatch()
        {
            var stopwatch = new Stopwatch();
            
            var batch = new List<T>();
            var benchmarks = new List<RateRecord>(5);
            IEnumerator<T> enumerator = null;
            
            try
            {
                enumerator = _collection.GetEnumerator();
                
                uint count = 0;
                stopwatch.Start();
                
                while(enumerator.MoveNext())
                {   
                    if(count == batchLength)
                    {
                        benchmarks.Add(new RateRecord { Length = BatchLength, ElapsedTicks = stopwatch.ElapsedTicks });
                        
                        var currentBatch = batch.ToList();
                        batch.Clear();
                        
                        if(benchmarks.Count == 10)
                        {
                            var currentRate = benchmarks.Average(x => x.Rate);
                            if(currentRate > bestRate.Rate)
                            {
                                bestRate = new RateRecord { Length = BatchLength, ElapsedTicks = (long)benchmarks.Average(x => x.ElapsedTicks) };
                                batchLength = NextPowerOf2(batchLength);
                            }
                            // Set margin of error at 10%
                            else if((bestRate.Rate * .9) > currentRate)
                            {
                                // Shift the current length and make sure it's >= 1
                                var currentPowOf2 = ((batchLength >> 1) | 1);
                                batchLength = PreviousPowerOf2(currentPowOf2);
                            }
                            
                            benchmarks.Clear();
                        }
                        count = 0;
                        stopwatch.Restart();
                        
                        yield return currentBatch;
                    }
                    
                    batch.Add(enumerator.Current);
                    count++;
                }
            }
            finally
            {
                if(enumerator != null)
                    enumerator.Dispose();
            }
            
            stopwatch.Stop();
        }
        
        uint PreviousPowerOf2(uint x)
        {
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            
            return x - (x >> 1);
        }
        
        uint NextPowerOf2(uint x)
        {
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            
            return (x+1);
        }
    }
