    private void button1_Click(object sender, EventArgs e)
    {
        Connect("localhost", "hello localhost " + Guid.NewGuid());
    }
            
    static void Connect(String server, String message)
    {
        try
        {               
            Int32 port = 25565;
            TcpClient client = new TcpClient(server, port);             
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();
    
            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length);                                
            stream.Close();
            client.Close();
        }
        catch (ArgumentNullException e)
        {
            Debug.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Debug.WriteLine("SocketException: {0}", e);
        }          
    }
