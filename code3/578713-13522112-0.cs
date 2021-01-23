    private Outlook.Application applicationObject;
    private Outlook.Explorers explorers;
    public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref System.Array custom)
    {
        MessageBox.Show("on connection");
        applicationObject = (Outlook.Application)application;
        explorers = applicationObject.Explorers;
        explorers.NewExplorer += new Microsoft.Office.Interop.Outlook.ExplorersEvents_NewExplorerEventHandler(Explorers_NewExplorer);
    }
