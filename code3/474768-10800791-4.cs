    public class Calculations
    {
        public class Result
        {
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
