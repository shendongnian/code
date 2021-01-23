    public abstract class BaseClass
    {
        public static BaseClass operator +(BaseClass p1, BaseClass p2)
        {
            return p1 + p2;
        }
        
        public static BaseClass operator *(BaseClass p1, BaseClass p2)
        {
            return p1 * p2;
        }
    }
    public class ChildClass : BaseClass
    {
    }
    public class Matrix <T> where T : BaseClass
    {
        T[][] elements;
    }
