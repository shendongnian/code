     public partial class MainWindow : Window
        {
            const int PRINT_WAITFORCOMPLETION = 2;
            public MainWindow()
            {
                InitializeComponent();
    
                if (Application.Current.Properties["ArgFileName"] != null)
                {
                    string fname = Application.Current.Properties["ArgFileName"].ToString();
                    if (String.IsNullOrEmpty(fname))
                    {
                        fileLabel.Content = "No File Specified";
                    }
                    else
    	            {
                        fileLabel.Content = fname;
                        SHDocVw.InternetExplorer IE = new SHDocVw.InternetExplorer();
                        IE.DocumentComplete +=new SHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler(IE_DocumentComplete);
                        IE.PrintTemplateTeardown += new SHDocVw.DWebBrowserEvents2_PrintTemplateTeardownEventHandler(IE_PrintTemplateTeardown);
                        IE.Visible = true;
                        IE.Navigate2(fname);    
                    }      
                }
            }
    
           void IE_PrintTemplateTeardown(object pDisp)
            {
                if (pDisp is SHDocVw.InternetExplorer)
                {
                    SHDocVw.InternetExplorer IE = (SHDocVw.InternetExplorer)pDisp;               
                    IE.Quit();
                    System.Environment.Exit(0);
                }
            }
    
           void IE_DocumentComplete(object pDisp, ref object URL)
            {
                if (pDisp is SHDocVw.InternetExplorer)
                {
                    SHDocVw.InternetExplorer IE = (SHDocVw.InternetExplorer)pDisp;               
                    IE.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINT, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, 2);
                    
                }
            }
        }
