    public static class MyStatic
    {
        public static object Global;
    
        public static void SomeMethod()
        {
            var theGlobal = MyStatic.Global;
        }
    }
    
    public class MyNonStatic
    {
        public object Global;
    
        public void SomeMethod()
        {
            var theGlobal = this.Global;
        }
    }
