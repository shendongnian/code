        public MainWindow()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            InitializeComponent();
        }
 
        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {            
            string assemblyName = args.Name.Remove(args.Name.IndexOf(',')) + ".dll";
            
            string s = @"C:\dlls\" + assemblyName;
            if (File.Exists(s))
            {
                return Assembly.LoadFile(s);
            }
            return null;
        }
