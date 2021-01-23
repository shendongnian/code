    public interface ITest
    {
        T InterfaceMethod<T>(T arg);
    }
    public interface IAnotherTest
    {
        U AnotherMethod<U>(U arg) where U : class;
    }
    public class Test : ITest
    {
        private IAnotherTest _ianothertest;
        public T InterfaceMethod<T>(T arg)
        {
            object argU = arg as object;
            if (argU != null)
            {
                object resultU = _ianothertest.AnotherMethod(argU);
                T resultT = (T)Convert.ChangeType(resultU, typeof(T));
                return resultT;
            }
            return default(T);
        }
    }
