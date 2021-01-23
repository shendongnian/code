    Testing testing = new Testing();
    testing.MyMethod(); // calls Testing.MyMethod
    AA testingA = new Testing();
    testingA.MyMethod(); // calls AA.MyMethod
     public interface A
    {
        int MyMethod();
    }
    public class AA : A
    {
        public int MyMethod()
        {
            return 11;
        }
    }
    public interface B
    {
        int MyMethod();
    }
    public interface C : A, B
    {
        int MyMethod();
    }
    public class Testing : AA,C
    {
        public int MyMethod()
        {
            return 10;
        }
    }
