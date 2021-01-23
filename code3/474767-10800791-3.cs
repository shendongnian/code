    public class Calculations
    {
        public class Result
        {
            //Should these be public so that they are accessible
            //by Result CalculateChapter7(QuoteData quoteData)?
            public decimal Total { get; set; }
            public decimal Discount { get; set; }
            public decimal Comparison {get; set; }
        }
        public Result CalculateChapter7(QuoteData quoteData)
        {
            Result result = new Result();
            result.Total = ...;
            result.Discount = ...;
            result.Comparison = ...;
            return result;
        }
    }
