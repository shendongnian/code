    var worker = new BackgroundWorker();
    
    worker.DoWork += (sender, args) => {
        var request = HttpWebRequest.Create(url);
        request.Credentials = new NetworkCredential(email, password);
        // TODO: set proxy settings if necessary
        try {
            args.Result = ((HttpWebResponse)request.GetResponse()).StatusCode;
        } catch (WebException we) {
            args.Result = ((HttpWebResponse)we.Response).StatusCode;
        }
    };
    
    worker.RunWorkerCompleted += (sender, e) => {
        String msg = "";
        var code = (HttpStatusCode)e.Result;
        if (code == HttpStatusCode.OK)
            msg = "Connectivity OK";
        else if (code == HttpStatusCode.Forbidden)
            msg = "Wrong username or password";
        else if (code == HttpStatusCode.NotFound)
            msg = "Wrong organisation";
        else
            msg = "Connectivity Error: " + code;
        label.Text = msg;
        log.d(msg);
    };
