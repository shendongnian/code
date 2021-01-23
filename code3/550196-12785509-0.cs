    public class Stock
    { 
        private static int FaceValue {get; set;}
        private static int Percent 
        {
            return FaceValue * 100;
        }
        Public void UpdateStock()
        {
           //only a single property to update now
           Interlocked.Increment(FaceValue);
        }
        //   method that reads the two properties
        public int[] GetStockQuote()
        {
            return new int[] { FaceValue, Percent};
        }
    }
