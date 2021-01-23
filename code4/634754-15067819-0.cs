            void StartThread()
            {
                DispatcherTimer TradeThread = new DispatcherTimer();
                TradeThread.Interval = TimeSpan.FromMilliseconds(1000);
                TradeThread.Tick += new EventHandler(BindData);
                TradeThread.Start();
            }
            Boolean _receivedData = true;
            void BindData(object sender, EventArgs e)
            {
                if(_receivedData)
                {
                    _receivedData = false;
                    WebClient wc = new WebClient();
                    wc.DownloadStringAsync(new Uri("some URL"));
                    wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
                }
            }
            void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
            {
                _receivedData = true;
                JObject jsonObject = JObject.Parse(e.Result);
                ///// some code 
