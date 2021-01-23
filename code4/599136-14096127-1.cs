    public interface IDependency
    {
        void DoSomeStuff();
    }
    public class ClassUnderTest
    {
        private IDependency _dependency;
        public ClassUnderTest(IDependency dependency)
        {
            _dependency = dependency;
        }
        public ClassUnderTest() : this(new Dependency())
        {}
        public void ImportantStuff()
        {
            _dependency.DoSomeStuff();
        }
    }
