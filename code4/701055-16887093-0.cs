    public static bool sendTo(IPEndPoint ip, String data)
    {
        TcpClient client = null;
        NetworkStream stream = null;
        StreamWriter writer = null;
        StreamReader reader = null;
        try
        {
            client = new TcpClient();
            client.Connect(ip);
            stream = c.GetStream();
            writer = new StreamWriter(stream);
            writer.WriteLine(data);
            writer.Flush();
            reader = new StreamReader(stream);
            string response = reader.ReadLine();
 
            if (response == "roger-alpha-tango")
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
        finally
        {
            if (writer != null) writer .Dispose();
            if (reader != null) reader .Dispose();
            if (stream != null) stream.Dispose();
            if (client != null) { client.Close(); client.Dispose(); }
        }
        return false;
    }
