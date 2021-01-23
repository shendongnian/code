    public class ParentClass
    {
    }
    public class ChildClass :  ParentClass
    {
    }
    public static class StaticClass
    {
        public static void SomeMethod(ParentClass d)
        {
            var t = d.GetType();
        }
    }
    public class StaticChildren
    {
        public void Children()
        {
            var p = new ChildClass();
            StaticClass.SomeMethod(p);
        }
    }
