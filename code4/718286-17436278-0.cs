    ExposedWebView webView = new ExposedWebView();
    webView.CreateWebView += HandleCreateWebView;
    	void HandleCreateWebView (object o, CreateWebViewArgs args)
    	{
    		Window info = new Window("");
    		info.DefaultWidth = 1000;
    		info.DefaultHeight = 700;
    		VBox vbox2 = new VBox();
    		WebView child = new WebView();
    		child.NavigationRequested += HandleNavigationRequested1;
    		vbox2.PackStart(child);
    		info.Add (vbox2);
    		info.ShowAll();
    		args.RetVal = child;
    	}
    
    
    class ExposedWebView : WebKit.WebView {
    	public event CreateWebViewHandler CreateWebView
    	{
    		add
    		{
    			Signal signal = Signal.Lookup (this, "create-web-view", typeof(CreateWebViewArgs));
    			signal.AddDelegate (value);
    		}
    		remove
    		{
    			Signal signal = Signal.Lookup (this, "create-web-view", typeof(CreateWebViewArgs));
    			signal.RemoveDelegate (value);
    		}
    	}
    
    	[DefaultSignalHandler (Type = typeof(WebView), ConnectionMethod = "OverrideCreateWebView")]
    	protected virtual WebView OnCreateWebView (WebFrame frame)
    	{
    		ExposedWebView webView = new ExposedWebView();
    		Value empty = Value.Empty;
    		ValueArray valueArray = new ValueArray (2u);
    		Value[] array = new Value[2];
    		array [0] = new Value (this);
    		valueArray.Append (array [0]);
    		array [1] = new Value (frame);
    		valueArray.Append (array [1]);
    		GLib.Object.g_signal_chain_from_overridden (valueArray.ArrayPtr, ref empty);
    		Value[] array2 = array;
    		for (int i = 0; i < array2.Length; i++)
    		{
    			Value value = array2 [i];
    			value.Dispose ();
    		}
    		return webView;
    	}
    }
    
    public delegate void CreateWebViewHandler (object o, CreateWebViewArgs args);
    
    public class CreateWebViewArgs : SignalArgs
    {
    	//
    	// Properties
    	//
    	
    	public WebFrame Frame
    	{
    		get
    		{
    			return (WebFrame)base.Args [0];
    		}
    	}
    }
