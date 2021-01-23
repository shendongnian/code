    SHDocVw.InternetExplorer IE = new SHDocVw.InternetExplorer();
    public Form1()
    {
        InitializeComponent();
        
        IE.DownloadComplete += new DWebBrowserEvents2_DownloadCompleteEventHandler(IE_DownloadComplete);
        object URL = "wcms.hankookilbo.com";
        IE.Visible = true;
                    
        IE.Navigate2(ref URL);
        this.Visible = false;
    }
    private void IE_DownloadComplete()
    {
        IE.ExecWB(OLECMDID.OLECMDID_OPTICAL_ZOOM, OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, 200, 0);
        
    }
