    private void button2_Click(object sender, EventArgs e) //button to start takedown
    {
         byte[] packetData = System.Text.ASCIIEncoding.ASCII.GetBytes("<Packet OF Data Here>");
         string IP = textBox1.Text; // take input by user
         int port = 80;
    
         IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);
    
         Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
         client.SendTo(packetData, ep);
    }
