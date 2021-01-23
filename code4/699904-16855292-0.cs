     public class FirstClass
    {
    }
    public class SecondClass
    {
    }
    public class ThridClass
    {
    }
    public static class Extensions
    {
        public static SecondClass GetSecondClass(this FirstClass f)
        {
            return new SecondClass();
        }
        public static ThridClass GetThridClass(this SecondClass s)
        {
            return new ThridClass();
        }
    }
