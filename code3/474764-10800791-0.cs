    public class Calculations
    {
        public class Result
        {
            decimal Total { get; set; }
            decimal Discount { get; set; }
            decimal Comparison {get; set; }
        }
        public decimal CalculateChapter7(QuoteData quoteData)
        {
            Result result = new Result();
            result.Total = ...;
            result.Discount = ...;
            result.Comparison = ...;
            return result;
        }
    }
