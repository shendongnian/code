    using System.Reflection;
    ...
    public class MyClass{
        public MyClass()
        { 
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
        }
        private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            return typeof(MyClass).Assembly;
        }
    }
