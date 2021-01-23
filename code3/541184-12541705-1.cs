    public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            Log("*****//Install Phase\\****");
            //Do here watever you want at install time            
        }
    public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            Log("*****//Uninstall Phase\\****");
            //Do here whatever you want at uninstall time
            Process.Start("chrome.exe", "http://www.yoursitename.com");
        }
