    public partial class App
    {
        public MyClass MyClassInstance { get; private set; }
    
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MyClassInstance = new MyClass();
        }
    }
