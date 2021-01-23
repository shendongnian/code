        static void Main(string[] args)
        {
            MyClass o = null;
            var kernel = new StandardKernel();
            kernel.Bind<MyClass>().ToSelf().Intercept().With(new MyInterceptor());
            o = kernel.Get<MyClass>();
            o.Echo("Hello World!"); // Error
            o.Double(5);
            Console.ReadKey(true);
        }
