     public delegate void Senddelegate();
        
        Senddelegate = sendyourkey;
    
        webBrowser1.BeginInvoke(new Senddelegate(sendyourkey));
    
    
        public void sendyourkey()
         {
          SendKeys.Send("r");
         }
