    Fiddler.FiddlerApplication.BeforeRequest += delegate(Fiddler.Session oS)
    {
        Monitor.Enter(oAllSessions);
        oAllSessions.Add(oS);
        Monitor.Exit(oAllSessions);
    };
    webBrowser1.Navigate("http://www.youtube.com/");
    while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
    {
        System.Windows.Forms.Application.DoEvents();
    }
