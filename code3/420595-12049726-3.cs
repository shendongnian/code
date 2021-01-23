    public static string sendStringRequest(String hostname, int port, string message) {
    
     try {
      byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
    
      TcpClient client = new TcpClient(hostname, port);
    
      NetworkStream stream = client.GetStream();
      BinaryWriter writer = new BinaryWriter(stream);
    
      //first 4 bytes - length!
      writer.Write(Convert.ToByte("0"));
      writer.Write(Convert.ToByte("0"));
      writer.Write(Convert.ToByte("0"));
      writer.Write(Convert.ToByte(data.Length));
      writer.Write(data);
    
      data = new Byte[256];
    
      // String to store the response ASCII representation.
      String responseData = String.Empty;
    
      Int32 bytes = stream.Read(data, 0, data.Length);
    
      responseData = System.Text.Encoding.ASCII.GetString(data, 4, (bytes - 4));
    
      // Close everything.
      stream.Close();
      client.Close();
      return responseData;
     } catch (ArgumentNullException e) {
      MessageBox.Show("ArgumentNullException: " + e);
      return "null";
     } catch (SocketException e) {
      MessageBox.Show("SocketException: " + e);
      return "null";
     }
    
    }
