    public delegate void geckoWebBrowserDelegate();
    
    public void scrollWithTheads()
    {
       Thread oThread = new Thread(new geckoWebBrowserDelegate(scrollWithThread));
       oThread.Start();
    }
    
    private void scrollWithThread()
    {
      _myGeckoWebBrowser.Invoke("scroll");
    }
    
    private void scroll()
    {
     GeckoDivElement div1 = new  GeckoDivElement(_myGeckoWebBrowser.Document.GetElementById("t1::scroller").DomObject);
     GeckoElementCollection divs = div1.GetElementsByTagName("div");
     GeckoDivElement div = new GeckoDivElement(divs[0].DomObject);
    div.ScrollIntoView(true);
    div.ScrollTop += 10;
    }
