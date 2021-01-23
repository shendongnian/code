    void SendVideoBuffer(object bufferIn) 
        { 
     
     var tcp = new TcpClient(ConfigurationSettings.AppSettings[0].ToString(), 6000); 
                       var ns = tcp.GetStream(); 
                       if (ns != null) 
                       { 
                           var buffer = (System.Drawing.Image)bufferIn;
                           lock(buffer) 
                                buffer.Save(ns, System.Drawing.Imaging.ImageFormat.Jpeg);
                           ns.Close(); 
                           tcp.Close(); 
            }
    }
