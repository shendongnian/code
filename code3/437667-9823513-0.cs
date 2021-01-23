    public interface Interface1
    {
        void Method1();
    }
    public interface Interface2 : Interface1
    {
        void Method2();
    }
    public class Class1 : Interface1
    {
        public void Method1()
        {
        }
    }
    public class Class2 : Class1, Interface2
    {
        public void Method2()
        {
        }
    }
