    public class ParentClass
    {
    }
    public static class StaticClass
    {
        public static void SomeMethod(ParentClass d)
        {
            var t = d.GetType();
        }
    }
