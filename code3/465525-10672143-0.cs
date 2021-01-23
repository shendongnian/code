     public static TestAttachment DeserializeMTOMMessage(byte[] MTOMMessage) 
        { 
            try 
            { 
                MemoryStream MTOMMessageInMemory = new MemoryStream(MTOMMessage);
                XmlDictionaryReader TR = XmlDictionaryReader.CreateMtomReader(MTOMMessageInMemory, Encoding.UTF8, XmlDictionaryReaderQuotas.Max); 
                DataContractSerializer DCS = new DataContractSerializer(typeof(TestAttachment)); 
                return (TestAttachment)DCS.ReadObject(TR); 
            } 
            catch
            {
                
                return null;
            } 
        } 
