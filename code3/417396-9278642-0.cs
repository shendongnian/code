    class MyClass
    {
      private readonly Action<List<string>> _updateAction;
    
      private readonly List<string> _collection = new List<string>();
    
      public MyClass(Action<List<string>> updateAction)
      {
        _updateAction = updateAction;
      }
    
      public void Update()
      {
        _updateAction(_collection);
      }
    }
  
    class MyClassTester
    {
      public static void Test()
      {
        MyClass weekdayAdder = new MyClass(c => c.Add(DateTime.Now.DayOfWeek.ToString()));
        MyClass timeAdder = new MyClass((c) => c.Add(DateTime.Now.ToShortTimeString()));
    
        weekdayAdder.Update();
        weekdayAdder.Update();
    
        timeAdder.Update();
        timeAdder.Update();
        timeAdder.Update();
      }
    }
