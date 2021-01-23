    public class WindowsFormsWebBrowser : WindowsFormsHost
    {
    	public static readonly DependencyProperty HtmlProperty =
    		DependencyProperty.Register(
    			"Html",
    			typeof(string),
    			typeof(WindowsFormsWebBrowser),
    			new PropertyMetadata(string.Empty, OnHtmlChanged, null));
    
    	public static readonly DependencyProperty IsContentMenuEnabledProperty =
    		DependencyProperty.Register(
    		"IsContentMenuEnabled",
    		typeof(bool),
    		typeof(WindowsFormsWebBrowser),
    		new PropertyMetadata(true, OnIsContextMenuEnabledChanged));
    
    	private readonly System.Windows.Forms.WebBrowser webBrowser = new System.Windows.Forms.WebBrowser();
    
    	public WindowsFormsWebBrowser()
    	{
    		Child = webBrowser;
    	}
    
    	public string Html
    	{
    		get { return GetValue(HtmlProperty) as string; }
    		set { SetValue(HtmlProperty, value); }
    	}
    
    	public bool IsContentMenuEnabled
    	{
    		get { return (bool)GetValue(IsContentMenuEnabledProperty); }
    		set { SetValue(IsContentMenuEnabledProperty, value); }
    	}
    
    	private static void OnHtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    	{
    		var browser = d as WindowsFormsWebBrowser;
    
    		if (browser == null)
    		{
    			return;
    		}
    
    		browser.webBrowser.DocumentText = (string)e.NewValue;
    	}
    
    	private static void OnIsContextMenuEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    	{
    		var browser = d as WindowsFormsWebBrowser;
    
    		if (browser == null)
    		{
    			return;
    		}
    
    		browser.webBrowser.IsWebBrowserContextMenuEnabled = (bool)e.NewValue;
    	}
    }
