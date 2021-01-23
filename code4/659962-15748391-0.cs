    public void OnMessage(IMessage message)
    { 
        ITextMessage msg = (ITextMessage)message;
        message.Acknowledge();
       
        if (txtConsole.InvokeRequired)
        {
            txtConsole.Invoke(new Action(() =>
              {
                 txtConsole.AppendText(Environment.NewLine + msg.Text);
              }));
        }
        else
        {
            txtConsole.AppendText(Environment.NewLine + msg.Text);
        }
    }
