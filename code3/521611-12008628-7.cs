    static class StrategyFactory
    {
        static IStrategy CreateStrategy(string input)
        {
            if (input == "condition1")
            {
                return new StrategyForCondition1();
            }
            else if (input == "condition2")
            {
                return new StrategyForCondition2();
            }
        }
    }
