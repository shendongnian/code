    using System;
    
    class SmaSeries
    {
        public SmaSeries(ISeries<decimal> parent, int periods,
             TierKind? runOnTier = null) { }
        static void Main()
        {
            object[] args = new object[] 
             {
                new DecimalSeries(),
                20,
                new Nullable<TierKind>(TierKind.Client)
             };
    
            object obj = Activator.CreateInstance(typeof(SmaSeries), args);
        }
    }
    enum TierKind { Client }
    interface ISeries<T> { }
    class DecimalSeries : ISeries<decimal> { }
