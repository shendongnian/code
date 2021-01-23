    public class MyClass
    {
        public int MyMethod()
        {
            return 0;
        }
        public static int MyMethod() //Here compiler says, that you've already got method MyMethod with same parameter list
        {
            return 0;
        }
    }
