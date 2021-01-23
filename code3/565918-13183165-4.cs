    public interface ITest {
        void DoSomethingBland();
    }
    public interface ITest<T> : ITest {
        void DoSomethingSpecific(T foo);
    }
