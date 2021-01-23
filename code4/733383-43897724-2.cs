    private void CreateUDPClient()
    {
        IPEndPoint TargetIP = new IPEndPoint(IPAddress.Parse("192.168.0.25"), 5555);
        // Create a UDP socket.  
        Socket receiver = new Socket(AddressFamily.InterNetwork,  
                SocketType.Stream, ProtocolType.Udp);  
        try {  
            // Create the state object.  
            StateObject state = new StateObject();  
            state.workSocket = receiver;  
  
            // Begin receiving the data from the remote device.  
            client.BeginReceive(state.buffer, 0, 256, 0,  
                new AsyncCallback(ReceiveMessage), state);  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }  
    }
