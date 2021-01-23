    string sSerialData = "";
    
    SerializeQueueType<BaseClassType>(oDerivedObject, out sSerialData)
    
    
    private bool SerializeDerivedObject<T>(T oDerivedObject, out string sOutput)
    {
        bool bReturn = false;
    
        sOutput = "";
    
        try
        {
      
            Type[] arrTypes = new Type[1];
            arrTypes[0] = oDerivedObject.GetType();
    
            XmlSerializer xmlSerl = new XmlSerializer(typeof(T), arrTypes); 
            System.IO.MemoryStream memStream = new System.IO.MemoryStream();
            xmlSerl.Serialize(memStream, oDerivedObject); 
    
            memStream.Position = 0;
    
            using (var reader = new System.IO.StreamReader(memStream, Encoding.UTF8))
            {
                sOutput = reader.ReadToEnd();
            }
    
            bReturn = true;
    
        }
        catch (Exception ex)
        {
            //_log.Error(ex);
        }
    
    
        return bReturn;
    
    } 
