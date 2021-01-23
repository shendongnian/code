    using ( webView = WebCore.CreateWebView( 800, 600 ) )
    {
        webView.Source = new Uri( "http://www.google.com" );
    
        view.LoadingFrameComplete += ( s, e ) =>
        {
            if ( !e.IsMainFrame )
                return;
    
            BitmapSurface surface = (BitmapSurface)view.Surface;
            surface.SaveToPNG( "result.png", true );
    
            WebCore.Shutdown();
        }
    }
    
    WebCore.Run();
