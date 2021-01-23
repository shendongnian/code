    using System;
    abstract class ATest : IDisposable
    {
        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
    class Test : ATest
    {
    }
    class OtherClass
    {
        public static void Main()
        {
            Test t = new Test();
            ((IDisposable)t).Dispose();
        }
    }
