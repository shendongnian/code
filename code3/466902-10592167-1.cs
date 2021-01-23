    public static void TestThat(TestCaseBase.Action action)
    {
        TestCaseResult result = action.Invoke();
        if(System.Attribute.IsDefined(action.Method, typeof(TestDescriptionAttribute)))
        {
            var attribute = (TestDescriptionAttribute)System.Attribute.GetCustomAttribute(action.Method,
                typeof(TestDescriptionAttribute));
            Console.WriteLine(attribute.TestDescription);
        }
    }
