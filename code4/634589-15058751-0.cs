    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        public Installer1()
        {
            InitializeComponent();
            this.AfterInstall += new InstallEventHandler(Installer1_AfterInstall);
        }
        void Installer1_AfterInstall(object sender, InstallEventArgs e)
        {
            string sTargetDir = Context.Parameters["TargetDir"];
            string sAppConfig = Path.Combine(sTargetDir, "<your app>.exe.config");
            string sDBPath = Path.Combine(sTargetDir, "<your db>.mdb");
            XDocument doc = XDocument.Load(sAppConfig);
            var elem = doc.Root.Element("/configuration/connectionStrings/add[@name='<your connection name>']");
            string connectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", sDBPath);
            elem.SetAttributeValue("connectionString", connectionString);
            doc.Save(sAppConfig);
       }
    }
