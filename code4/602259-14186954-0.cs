    public abstract class TestBase<T> where T : TestDmoBase
    {
        public abstract void LoadCrud(T dmo);
    }
    public class Test : TestBase<TestDmo>
    {
        public override void LoadCrud(TestDmo dmo)
        {
            ...
        }
    }
