    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Navigation;
    
    namespace OpenDefaultBrowser
    {
    	public partial class MainWindow : Window
    	{
    		private static bool willNavigate;
    
    		public MainWindow()
    		{
    			InitializeComponent();
    		}
    
    		private void webBrowser1_Navigating(object sender, NavigatingCancelEventArgs e)
    		{
    			// first page needs to be loaded in webBrowser control
    			if (!willNavigate)
    			{
    				willNavigate = true;
    				return;
    			}
    
    			// cancel navigation to the clicked link in the webBrowser control
    			e.Cancel = true;
    
    			var startInfo = new ProcessStartInfo
    			{
    				FileName = e.Uri.ToString()
    			};
    
    			Process.Start(startInfo);
    		}
    	}
    }
