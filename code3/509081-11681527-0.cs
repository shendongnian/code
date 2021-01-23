        public class MyStopwatch : Stopwatch
        {
            public TimeSpan StartOffset { get; private set; }
            public MyStopwatch(TimeSpan startOffset)
            {
                StartOffset = startOffset;
            }
            public new long ElapsedMilliseconds
            {
                get
                {
                    return base.ElapsedMilliseconds + (long)StartOffset.TotalMilliseconds;
                }
            }
            public new long ElapsedTicks
            {
                get
                {
                    return base.ElapsedTicks + StartOffset.Ticks;
                }
            }
        }
