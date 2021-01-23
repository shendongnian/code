    interface IFoo
    {
        void SayHello();
    }
    interface IBar : IFoo
    {
        new void SayHello();
    }
    class myFooBarImp : IFoo, IBar
    {
         void IFoo.SayHello()
        {
            Console.WriteLine("Hello from IFoo implementation");
        }
         void IBar.SayHello()
        {
            Console.WriteLine("Hello from IBar implementation");
        }
        public void SayHello()
        {
            Console.WriteLine("Hello from SayHello");
        }
    }
     class Program1
    {      
        public static void Main()
        {
            myFooBarImp obj = new myFooBarImp();
            obj.SayHello();
            (obj as IFoo).SayHello();
            (obj as IBar).SayHello();
            return;        
         }
    }
