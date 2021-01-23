    //in file foolaunch.cs
    
    using System;
    
    namespace Foo
    {
        public class Launch
        {
            protected void Method1()
            {
                Console.WriteLine("Hello from Foo.Launch.Method1");
            }
        }
    }
    
    // csc /target:library /out:FooLaunch.dll foolaunch.cs
    
    //now subclassing foo.Launch
    
    //in file subfoolaunch.cs
    
    namespace Foo
    {
        extern alias F1;
        public class Launch : F1.Foo.Launch
        {
            public void Method3()
            {
                Method1();
            }
        }
    }
    
    
    // csc /target:library /r:F1=foolaunch.dll /out:SubFooLaunch.dll subfoolaunch.cs
    
    // using
    // in file program.cs
    
    namespace ConsoleApplication
    {
        extern alias F2;
        class Program
        {
            static void Main(string[] args)
            {
                var launch = new F2.Foo.Launch();
                launch.Method3();
            }
        }
    }
    
    // csc /r:FooLaunch.dll /r:F2=SubFooLaunch.dll program.cs
