    public void StartServer()
    {
        TcpListener listener = null;
        TcpClient client = null;
        NetworkStream nwStream = null; 
        try
        {
            listener = new TcpListener(IPAddress.Any, 4444);
            listener.Start();
        }
        catch(Exception ex)
        { Console.WriteLine(ex.Message); }
        byte[] buffer = new byte[1024];
        try
        {
            bool waiting = true;
            while(waiting)
            {
                if(listener.Pending())
                {
                    client = listener.AcceptTcpClient();
                    nwStream = client.GetStream();
                    using(var ms = new MemoryStream())
                    {
                        CreateDataSet().WriteXml(ms);
                        ms.Position = 0;
                        int read = 0;
                        while((read = ms.Read(buffer, 0, 1024)) != 0)
                        {
                            nwStream.Write(buffer, 0, read);
                        }
                    }
                    nwStream.Flush();
                    nwStream.Close();
                    client.Close();
                    waiting = false;
                }
            }
        }
        catch(Exception ex)
        {
           Console.WriteLine(ex.Message);
        }
    }
    private DataSet CreateDataSet()
    {
        //Create your dataset here and return something
    }
