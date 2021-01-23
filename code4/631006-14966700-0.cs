    /// <summary>
    /// Initialise the WebView control
    /// </summary>
    private void InitialiseWebView()
    {
    	// Disable caching.
    	BrowserSettings settings = new BrowserSettings();
    	settings.ApplicationCacheDisabled = true;
    	settings.PageCacheDisabled = true;
    
    	// Initialise the WebView.
    	this.webView = new WebView(string.Empty, settings);
    	this.WebView.Name = string.Format("{0}WebBrowser", this.Name);
    	this.WebView.Dock = DockStyle.Fill;
    
    	// Setup and regsiter the marshal for the WebView.
    	this.chromiumMarshal = new ChromiumMarshal(new Action(() => { this.FlushQueuedMessages(); this.initialising = false; }));
    	this.WebView.RegisterJsObject("marshal", this.chromiumMarshal);
    	
    	// Setup the event handlers for the WebView.
    	this.WebView.PropertyChanged += this.WebView_PropertyChanged;
    	this.WebView.PreviewKeyDown += new PreviewKeyDownEventHandler(this.WebView_PreviewKeyDown);
    
    	this.Controls.Add(this.WebView);
    }
    
    /// <summary>
    /// Handles the PropertyChanged event of CefSharp.WinForms.WebView.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event arguments.</param>
    private void WebView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
    	// Once the browser is initialised, load the HTML for the tab.
    	if (!this.webViewIsReady)
    	{
    		if (e.PropertyName.Equals("IsBrowserInitialized", StringComparison.OrdinalIgnoreCase))
    		{
    			this.webViewIsReady = this.WebView.IsBrowserInitialized;
    			if (this.webViewIsReady)
    			{
    				string resourceName = "Yaircc.UI.default.htm";
    				using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
    				{
    					using (StreamReader reader = new StreamReader(stream))
    					{
    						this.WebView.LoadHtml(reader.ReadToEnd());
    					}
    				}
    			}
    		}
    	}
    
    	// Once the HTML has finished loading, begin loading the initial content.
    	if (e.PropertyName.Equals("IsLoading", StringComparison.OrdinalIgnoreCase))
    	{
    		if (!this.WebView.IsLoading)
    		{
    			this.SetSplashText();
    			if (this.type == IRCTabType.Console)
    			{
    				this.SetupConsoleContent();
    			}
    
    			GlobalSettings settings = GlobalSettings.Instance;
    			this.LoadTheme(settings.ThemeFileName);
    
    			if (this.webViewInitialised != null)
    			{
    				this.webViewInitialised.Invoke();
    			}
    		}
    	}
    }
