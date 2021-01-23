    public class SqlFunctionsFacade : ISqlFunctions
    {
        public string StringConvert(decimal? number)
        {
            return number?.ToString();
        }
    }
