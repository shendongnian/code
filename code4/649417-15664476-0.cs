    public T GetBody<T>(BrokeredMessage brokeredMessage)
    {
      var ct = brokeredMessage.ContentType;
      Type bodyType = Type.GetType(ct, true);
    
      var stream = brokeredMessage.GetBody<Stream>();
      DataContractSerializer serializer = new DataContractSerializer(bodyType);
      XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(stream, XmlDictionaryReaderQuotas.Max);
      object deserializedBody = serializer.ReadObject(reader);
      T msgBase = (T)deserializedBody;
      return msgBase;
    }
