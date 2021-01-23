      public class DoSomething
      {
        public void CallMe<T>()
        {
          Type type = typeof(T);
          type.GetMethod("DoThis").Invoke(null, new object[] { "text" });
        }
      }
