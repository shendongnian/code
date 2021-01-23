	// Create and acquire a Global Javascript object.
	// These object persist for the lifetime of the web-view.
	using ( JSObject myGlobalObject = webView.CreateGlobalJavascriptObject( "myGlobalObject" ) )
	{
	    // The handler is of type JavascriptMethodEventHandler. Here we define it
	    // using a lambda expression.
	    myGlobalObject.Bind( "onLinkClicked", false, ( name ) =>
	    {
        	Debug.Print( String.Format( "User clicked: {0}", name ) );
	    } );
	}
