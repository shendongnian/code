    void netConnection_OnConnect(object sender, EventArgs e)
    {
        //The NetConnection object is connected now
        netConnection.Call("serverHelloMsg", new ServerHelloMsgHandler(), "some text");
    }
