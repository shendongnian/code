    public static class LockObject
    {
        public static readonly object Locker = new object();
    }
    public class OtherClass
    {
        public CallToMethodInOtherClass(List<int> list)
        {
           lock(LockObject.Locker)
           {
              int i = list.Count;
           } 
        }
    }
