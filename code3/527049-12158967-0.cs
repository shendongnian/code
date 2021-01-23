    using (Stream jsonstream = jsonHTTPResponse.GetResponseStream()) 
            { 
                DataContractJsonSerializer serializer = 
                                         new DataContractJsonSerializer(typeof(RootObject)); 
    
                 using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonstream)))
                {
                    vikiRootObject = (RootObject)serializer.ReadObject(jsonstream); 
    
                    using (MemoryStream ms2 = new MemoryStream())
                    {
                        ser.WriteObject(ms2, vikiRootObject);
                        string serializedJson = Encoding.UTF8.GetString(ms2.GetBuffer(), 0, (int)ms2.Length);
                    }
                }
    
     } 
