    public class TestWithEvents
    {
      //just using random delegate signatures here
      public event Action Handler1;
      public event Action<int, string> Handler2;
      public void RaiseEvents(){
        if(Handler1 != null)
            Handler1();
        if(Handler2 != null)
          Handler2(0, "hello world");
      }
    }
    public static class DynamicEventBinder
    {
      public static Delegate GetHandler(System.Reflection.EventInfo ev) {
        string name = ev.Name;
        //create an array of ParameterExpressions to pass to the Expression.Lambda method
        var parameters = ev.EventHandlerType.GetMethod("Invoke").GetParameters().
          Select((p, i) => Expression.Parameter(p.ParameterType, "p" + i)).ToArray();
        var lambda = Expression.Lambda(ev.EventHandlerType,
          Expression.Call(typeof(Console).GetMethod(
            "WriteLine",
            BindingFlags.Public | BindingFlags.Static,
            null,
            new[] { typeof(string) },
            null), Expression.Constant(name + " was fired!")), parameters);
        Console.WriteLine("Compiling dynamic lambda {0} for event \"{1}\"", lambda, name);
        return lambda.Compile();
      }
      //note - an unsubscribe might be handy - which would mean
      //caching all the events that were subscribed for this object
      //and the handler.  Probably makes more sense to turn this type
      //into an instance type that binds to a single object...
      public static void SubscribeAllEvents(object o){
        foreach(var e in o.GetType().GetEvents())
        {
          e.AddEventHandler(o, GetHandler(e));
        }
      }
    }
    [TestMethod]
    public void TestSubscribe()
    {
      TestWithEvents testObj = new TestWithEvents();
      DynamicEventBinder.SubscribeAllEvents(testObj);
      Console.WriteLine("Raising events...");
      testObj.RaiseEvents();
      //check the console output
    }
