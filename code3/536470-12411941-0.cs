    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication10
    {
        public partial class Form1 : Form
        {
    	public Form1()
    	{
    	    InitializeComponent();
    	}
    
    	private void Form1_Load(object sender, EventArgs e)
    	{
    	    // When the form loads, open this web page.
    	    webBrowser1.Navigate("http://www.dotnetperls.com/");
    	}
    
    	private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    	{
    	    // While the page has not yet loaded, set the text.
    	    this.Text = "Navigating";
    	}
    
    	private void webBrowser1_DocumentCompleted(object sender,
    	    WebBrowserDocumentCompletedEventArgs e)
    	{
    	    // Better use the e parameter to get the url.
    	    // ... This makes the method more generic and reusable.
    	    this.Text = e.Url.ToString() + " loaded";
    	}
        }
    }
