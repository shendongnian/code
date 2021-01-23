      WebPreferences prefs = new WebPreferences(){ ProxyConfig = "xxx.xxx.xxx.xxx:port" }
      session = WebCore.CreateWebSession(prefs);
      browser.WebSession = session; 
      browser.Source = new System.Uri("http://checkip.dyndns.com/", System.UriKind.Absolute);
      
