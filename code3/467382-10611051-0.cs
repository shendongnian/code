    public interface IFactory { T Resolve<T>(); }
    public interface ISomeObject { void CallSomeMethod(); }
    public class Tests
    {
        [Test]
        public void Example()
        {
            var factory = Substitute.For<IFactory>();
            MyMethod(factory);
        }
        public void MyMethod(IFactory container)
        {
            var myObject = container.Resolve<ISomeObject>();
            myObject.CallSomeMethod();
        }
    }
