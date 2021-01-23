    namespace TradeDataExtensions.Validation
    {
        public static class ClassWithSameName
        {
             public static bool IsActiveTrade(this TradeData tradeData){...}
        }
    }
    namespace TradeDataExtensions.Analytics
    {
        public static class ClassWithSameName
        {
             public static decimal ExpectedReturn(this TradeData tradeData){...}
        }
    }
