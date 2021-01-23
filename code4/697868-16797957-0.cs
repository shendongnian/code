    private static bool MyFilter(TestClass item)
    {
      return (item.ModulePosition) == 1 && (item.TopBotData == 2);
    }
    private static void Example()
    {
      List<TestClass> exampleList = test();
      List<TestClass> sortedList = exampleList.FindAll(MyFilter);
    }
