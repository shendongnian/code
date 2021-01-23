    System.Windows.Forms.WebBrowser web = new System.Windows.Forms.WebBrowser();
    web.ScrollBarsEnabled = false;
    web.ScriptErrorsSuppressed = true;
    web.Navigate("http://www.your_url.com/with_params");
    while (web.ReadyState != WebBrowserReadyState.Complete)
    Application.DoEvents();
    //this is where we start search the DOM for our meta information and extract the content attribute into a usable string.
    String meta = (web.Document.GetElementsByTagName("meta")[0]).GetAttribute("content");
    System.Console.WriteLine("Meta Value is {0}", meta);
