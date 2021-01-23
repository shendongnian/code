    using System.Reflection;
    using System.Windows;
    
    namespace WpfWbApp
    {
    	// By Noseratio (http://stackoverflow.com/users/1768303/noseratio)
    
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			this.WB.Loaded += (s, e) =>
    			{
    				// get the underlying WebBrowser ActiveX object;
    				// this code depends on SHDocVw.dll COM interop assembly,
    				// generate SHDocVw.dll: "tlbimp.exe ieframe.dll",
    				// and add as a reference to the project
    
    				var activeX = this.WB.GetType().InvokeMember("ActiveXInstance",
    					BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
    					null, this.WB, new object[] { }) as SHDocVw.WebBrowser;
    
    				// now we can handle previously inaccessible WB events 
    				activeX.FileDownload += activeX_FileDownload;
    			};
    
    			this.Loaded += (s, e) =>
    			{
    				this.WB.Navigate("http://technet.microsoft.com/en-us/sysinternals/bb842062");
    			};
    		}
    
    		void activeX_FileDownload(bool ActiveDocument, ref bool Cancel)
    		{
    			Cancel = true;
    		}
    	}
    }
