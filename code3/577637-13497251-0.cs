    [DataContract]
    public SampleObject
    {
       [DataMember("MyProperty")]
       public string MyProperty {get;set;}
    }
        private static byte[] SerializeRequest<T>(string contentType, T request)
        {
            using (MemoryStream requestObjectStream = new MemoryStream())
            {
                if (contentType == "applicaton/json")
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                    serializer.WriteObject(requestObjectStream, request);
                }
                else if (contentType == "application/xml")
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                    serializer.WriteObject(requestObjectStream, request);
                }
                else
                {
                    throw new Exception("invalid contentType");
                }
                requestObjectStream.Position = 0;
                return requestObjectStream.ToArray();
            }
        }
        private static T DeserializeResponse<T>(string acceptHeader, string responseString)
        {            
            if (acceptHeader == "applicaton/json")
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                MemoryStream responseObjectStream = new MemoryStream(Encoding.UTF8.GetBytes(responseString));
                return (T)serializer.ReadObject(responseObjectStream);
            }
            else if (acceptHeader == "application/xml")
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                MemoryStream responseObjectStream = new MemoryStream(Encoding.UTF8.GetBytes(responseString));
                return (T)serializer.ReadObject(responseObjectStream);
            }
            return default(T);
        }
