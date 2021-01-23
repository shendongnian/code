    namespace CLT
    {
        [RunInstaller(true)]
        public partial class ClientInstall : Installer
        {
            public ClientInstall()
            {
                InitializeComponent();
            }
           
            public override void Install(IDictionary stateSaver)
            {
                    base.Install(stateSaver);
                    System.Diagnostics.Process.Start(@"\Powerpoint.exe");
            }
    }
