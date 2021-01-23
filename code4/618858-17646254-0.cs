    public partial class TopLevelUserControlLauncher: UserControl
    {
        AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ResolveAssembly);
        InitializeComponent(); // this will construct TopLevelUserControl
    }
