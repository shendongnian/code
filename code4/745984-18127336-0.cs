            WebRequest w = HttpWebRequest.Create("http://www.google.com");
            Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
            Thread thread = new Thread(new ThreadStart(() =>
                {
                    WebResponse response = w.GetResponse();
                    dispatcher.BeginInvoke(new Action(() =>
                    {
                        // Handle response on the dispatcher thread.
                    }), null);
                }));
            thread.IsBackground = true;
            thread.Start();
