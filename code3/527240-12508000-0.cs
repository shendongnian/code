     [STAThread]
     static void Main(string[] args)
     {
         Interop.Hello.IHello Hello = new Interop.Hello.CHello();
         Hello.Print();
     }
