      public class DoSomething
      {
        Func<string, byte[]> action;
        public void CallMe<T>()
        {
          if (action == null)
            action = (Func<string, byte[]>)Delegate.CreateDelegate(typeof(Func<string, byte[]>), typeof(T).GetMethod("DoThis"));
          for(var i = 0; i < 1000; ++i)
            action("text");
        }
      }
