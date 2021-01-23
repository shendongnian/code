    AppDomainSetup setup = AppDomain.CurrentDomain.SetupInformation;
    AppDomain domain = AppDomain.CreateDomain("myAppDomain", null, setup)
    setup.ApplicationBase = file;
    
    Assembly assembly = domain.Load(AssemblyName.GetAssemblyName(
    AppDomain.CurrentDomain.BaseDirectory +
     "client.dll"));
    
    object frm = assy.CreateInstance("Client.Forms.MainForm");
    Application.Run((Form)frm);
