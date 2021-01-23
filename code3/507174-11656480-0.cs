    public interface ITest
    {
        T InterfaceMethod<T> (T arg);
    }
    public interface ITest2
    {
        U AnotherMethod<U>(U arg) where U : class;
    }
    public class Test<Tin> : ITest, ITest2 where Tin : class
    {
        public T InterfaceMethod<T> (T arg)
        {
            Tin argU = arg as Tin;
            if (argU != null)
            {
                Tin resultU = AnotherMethod(argU);
                T resultT = (T)Convert.ChangeType(resultU,typeof(T));
                return resultT;
            }
            return default(T);
        }
        public U AnotherMethod<U> (U arg) where U : class { return arg; }
    }
