      public class DoSomething
      {
        class Cache<T>
        {
          public readonly static Func<string, byte[]> action = (Func<string, byte[]>)Delegate.CreateDelegate(typeof(Func<string, byte[]>), typeof(T).GetMethod("DoThis"));
        }
        public void CallMe<T>()
        {
          Cache<T>.action("text");
        }
      }
