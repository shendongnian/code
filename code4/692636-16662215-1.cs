    namespace Gabriel.Extensions
    {
        public static class ClassWithSameName
        {
             public static bool IsActiveTrade(this TradeData tradeData){...}
        }
    }
    namespace John.Extensions
    {
        public static class ClassWithSameName
        {
             public static bool IsAGoodDeal(this TradeData tradeData){...}
        }
    }
