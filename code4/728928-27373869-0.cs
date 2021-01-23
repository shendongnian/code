    var gsm = new GsmCommMain(4, 115200, 200);
    
    private void Form1_Load(object sender, EventArgs e)
    {
        //gsm.PhoneConnected += new EventHandler(gsmPhoneConnected);   // not needed..
        gsm.PhoneDisconnected += new EventHandler(gsmPhoneDisconnected);
        gsm.Open();
        if(gsm.IsConnected()){
            this.onPhoneConnectedChange(true);
        }
    }
    
    private delegate void ConnctedHandler(bool connected);
    private void onPhoneConnectedChange(bool connected)
    {
        try
        {
            if (connected)
            {
    
                phoneStatus.Text = "OK";
            }
            else
            {
                phoneStatus.Text = "NG";
            }
        }
        catch (Exception exce)
        {
            logBox.Text += "\n\r" + exce.ToString();
        }
    }
    
    /*public void gsmPhoneConnected(object sender, EventArgs e)
    {
        this.Invoke(new ConnctedHandler(onPhoneConnectedChange), new object[] { true });
    }*/
    
    private void gsmPhoneDisconnected(object sender, EventArgs e)
    {
        this.Invoke(new ConnctedHandler(onPhoneConnectedChange), new object[] { false });
    }
