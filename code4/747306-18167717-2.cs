    public partial class MainFrame : Form
    {
        public static WebBrowser webBrowser = new WebBrowser();
        
        public static System.Threading.SynchronizationContext mainThreadContext = System.Threading.SynchronizationContext.Current;
    
    
        public MainFrame()
        {
            InitializeComponent();
        }
    }
    
    class Job
    {
        public void Process()
        {
            mainThreadContext.Send(delegate 
            {
                MainFrame.webBrowser.Navigate("http://www.google.com");
            }, null);
    
    	    bool ready = false;
            while (!ready)
            {
                mainThreadContext.Send(delegate 
                {
                    ready = MainFrame.webBrowser.ReadyState != WebBrowserReadyState.Complete;
                }, null);
                Thread.Sleep(1000);
                // if you don't have any UI on this thread, DoEvent is redundant
                Application.DoEvents(); 
            }
        }
    }
