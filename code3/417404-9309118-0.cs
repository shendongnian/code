    SHDocVw.InternetExplorer IE = new SHDocVw.InternetExplorer
    bool _isRunning = false;
    private void IE_DocumentComplete(object pDisp, ref obj URL)
    {
        //Prevent multiple Thread creations because the DocumentComplete event fires for each frame in an HTML-Document
        if (_isRunning) { return; }
        _isRunning = true;
        Thread t = new Thread(new ThreadStart(Do))
        t.SetApartmentState(ApartmentState.STA);
        t.Start();
    }
    private void Do()
    {
        mshtml.IHTMLDocument3 doc = this.IE.Document;
        
        mshtml.IHTMLElement player = doc.getElementById("player");
        if (player != null)
        {
            //Now we're able to call the objects properties, function (members)
            object value = player.GetType().InvokeMember("getLastSongPlayed", System.Reflection.BindingFlags.InvokeMethod, null, player, null);
            //Do something with the returned value in the "value" object above.
        }
    }
