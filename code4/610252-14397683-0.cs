    public void PingIP(string IP)
    {
        var ping = new Ping();
        ping.PingCompleted += new PingCompletedEventHandler(ping_PingCompleted); //here the event handler of ping
        ping.SendAsync(IP,"a"); 
    }
    delegate void updateTextBoxFromThread(String Text);
    void updateTextBox(String Text){
       if (this.textbox1.InvokeRequired){
           //textbox created by other thread.
           updateTextBoxFromThread d = new updateTextBoxFromThread(updateTextBox);
           this.invoke(d, new object[] {Text});
       }else{
          //running on same thread. - invoking the delegate will lead to this part.
          this.textbox1.text = Text;
       }
    }
    void ping_PingCompleted(object sender, PingCompletedEventArgs e)
    {
        if (e.Reply.Status == IPStatus.Success)
        {
           updateTextBox(Text);
        }
    }
