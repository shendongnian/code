       private void Engine()
       {
          while (true)
         {
            Thread.Sleep(1000);
            Ticker ltcusd = BtceApi.GetTicker(BtcePair.LtcUsd);
            UpdateText("LTC/USD: " + ltcusd.Last);
          }
        }
        private void UpdateText(string text)
        {
            //Inspect if the method is executing on background thread
            if (InvokeRequired)
            {
               //we are on background thread, use BeginInvoke to pass delegate to the UI thread
                BeginInvoke(new Action(()=>UpdateText(text)));
            }
            else
            {
               //we are on UI thread, it's ok to change UI
               label1.Text = text;            
            }
        }
        
