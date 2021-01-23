      //---------------------------------------------------------------------
            public static Byte[] ObjectToByteArray<T>(T obj)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    XmlSerializer xmlS = new XmlSerializer(typeof(T));
                    xmlS.Serialize(ms, obj);
    
                    return ms.ToArray();
                }
            }
            //---------------------------------------------------------------------
            public static T ByteArrayObject<T>(Byte[] bObj)
            {
                using (MemoryStream ms = new MemoryStream(bObj))
                {
                    XmlSerializer xmlS = new XmlSerializer(typeof(TheMessage));
                    return (T)xmlS.Deserialize(ms);
                }
            }
            //---------------------------------------------------------------------
            public static void Sending(Byte[] bData)
            {
                Stream stm = client.GetStream();
                
                // always write size first when using TCP
                Byte[] bSize = BitConverter.GetBytes(bData.Length);
                stm.Write(bSize, 0, bSize.Length);
                stm.Write(bData, 0, bData.Length);
            }
    
            //---------------------------------------------------------------------
            public static void Receiving(Byte[] bData)
            {
                Byte[] bSize = new Byte[sizeof(Int32)];
                s.Read(bSize, 0, bSize.Length);
    
                Byte[] bData = new Byte[BitConverter.ToInt32(bSize, 0)];
                s.Read(bData, 0, bData.Length);
    
                TheMessage m = ByteArrayObject<TheMessage>(bData);
            }
