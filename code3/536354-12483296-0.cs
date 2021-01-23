    using System.Windows.Forms;
    using System.Text.RegularExpressions;
    
    namespace Your.App
    {
    	public class PopupSuppress
    	{
    		WebBrowser _wb;
    		public PopupSupress()
    		{
    			_wb = new WebBrowser();
    			_wb.Navigated += new WebBrowserNavigatedEventHandler(_wb_Navigated);
    		}
    
    		void _wb_Navigated(object sender, WebBrowserNavigatedEventArgs e)
    		{
    			string alertRegexPattern = "alert\\([\\s\\S]*\\);";
    			//make sure to only write to _wb.DocumentText if there is a change.
    			//This will prompt a reloading of the page (and another 'Navigated' event) [see MSDN link]
    			if(Regex.IsMatch(_wb.DocumentText, alertRegexPattern))
    				_wb.DocumentText = Regex.Replace(_wb.DocumentText, alertRegexPattern, string.Empty);
    		}
    	}
    }
