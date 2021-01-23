    public class Stock
    { 
        private static int FaceValue {get; set;}
        Public void UpdateStock()
        {
           //only a single property to update now
           Interlocked.Increment(FaceValue);
        }
        //   method that reads the two properties
        public int[] GetStockQuote()
        {
            var currVal = FaceValue;
            return new int[] { currVal, currVal * 100 };
        }
    }
