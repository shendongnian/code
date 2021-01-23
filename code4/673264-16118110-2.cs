    public interface ITest {
        void Test();
    }
    public interface ITest2 {
        void Test();
    }
    public class Dual : ITest, ITest2
    {
        void ITest.Test() {
            Console.WriteLine("ITest.Test");
        }
        void ITest2.Test() {
            Console.WriteLine("ITest2.Test");
        }
    }
