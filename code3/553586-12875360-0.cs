            bool IsReady;
        void Go()
        {
            IsReady = false;
            brw.Navigate("url");
            do
            {
                Thread.Sleep(10);
                Application.DoEvents();
            } while (!IsReady);
        }
       void brw_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            IsReady = true;
        }
