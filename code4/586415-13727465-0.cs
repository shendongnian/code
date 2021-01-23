    [System.STAThreadAttribute()]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks","4.0.0.0")]
    public static void Main() {
        AppDomain.CurrentDomain.UnhandledException += (s,args)=>{
           MessageBox.Show("Unhandled Exception: "+args.ExceptionObject);
        };
        Storm.Designer.App app = new Storm.Designer.App();
        app.InitializeComponent();
        app.Run();
    }
