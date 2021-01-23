    public static class TestConditionExtension
    {
        public static ITestCondition<T> Foo<T>(this ITestCondition<T> condition)
        {
            return condition;
        }
    }
