    public static void TestThat(TestCaseBase.Action action)
    {
      TestCaseResult result = action.Invoke();
      var attrs = action.GetInvocationList()[0].Method.GetCustomAttributes(true);
    
      // I want to get the value of the TestDescription attribute here
    }
