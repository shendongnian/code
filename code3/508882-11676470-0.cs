    class SomeClass
    {
      public event Action SomeEvent;
    }
    // later
    var instance = new SomeClass();
    instance.SomeEvent += () => Console.WriteLine("it happeneed");
    var flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
    var type = typeof(SomeClass);
    var field = type.GetField("SomeEvent", flags);
    var method = field.FieldType.GetProperty("Method", flags);
    var target = field.FieldType.GetProperty("Target", flags);
    var methodInstance = field.GetValue(instance);
    ((MulticastDelegate)methodInstance).DynamicInvoke(new object[] { });
