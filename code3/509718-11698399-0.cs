     webView.Callback += new EventHandler<CallbackEventArgs>(webView_Callback);
        
        webView.CreateObject("client");
        webView.SetObjectCallback("client", "message");
        
        void webView_Callback(object sender, CallbackEventArgs e)
        {
            if (e.CallbackName == "message")
                System.Windows.Forms.MessageBox.Show(e.Args[0].ToString());
        }
