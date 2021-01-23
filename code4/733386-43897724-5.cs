    private void btn_SendtoTarget_Click(object sender, EventArgs e)
    {
        IPEndPoint TargetIP = new IPEndPoint(IPAddress.Parse(txt_Send2IP.Text),int.Parse(txt_Send2Port.Text));
        byte[] Message = Encoding.ASCII.GetBytes("TEST TEST TEST");
        // Create a UDP socket.  
        Socket sender = new Socket(AddressFamily.InterNetwork,  
            SocketType.Stream, ProtocolType.Udp);  
  
        try 
        {            
            // Connect to the remote endpoint.
            sender.Connect(TargetIP);  
            // Send message -- already contains the endpoint so no need to 
            // specify again
            sender.Send(Message, 0, Message.Length, SocketFlags.None);
            sender.Close();
        }
        catch (Exception)
        {
           // do something here...
        }
    }
