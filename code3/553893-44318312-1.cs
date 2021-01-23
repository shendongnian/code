        public class MovingAverage  
        {
            private Queue<Decimal> samples = new Queue<Decimal>();
            private int windowSize = 16;
            private Decimal sampleAccumulator;
            public Decimal Average { get; private set; }
            /// <summary>
            /// Computes a new windowed average each time a new sample arrives
            /// </summary>
            /// <param name="newSample"></param>
            public void ComputeAverage(Decimal newSample)
            {
                sampleAccumulator += newSample;
                samples.Enqueue(newSample);
                if (samples.Count > windowSize)
                {
                    sampleAccumulator -= samples.Dequeue();
                }
                Average = sampleAccumulator / samples.Count;
            }
        }
