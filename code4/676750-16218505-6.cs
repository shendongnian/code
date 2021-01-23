    TcpClient client = new TcpClient("192.168.1.64", 4444);
     using (NetworkStream netstream = client.GetStream())
     {
         using (BinaryWriter bw = new BinaryWriter(netstream))
         {
            bw.Write(img_byte.Length);
            bw.Write(img_byte, 0, img_byte.Length);
         }
                            
         client.Close();
     }
