    public class Program
    {
        [STAThreadAttribute]
        public static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve
                += new ResolveEventHandler(ResolveAssembly);
            WpfApplication1.App app = new WpfApplication1.App();
            app.InitializeComponent();
            app.Run();
        }
        public static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {   
          // check condition on the top of your original implementation
        }
    }
