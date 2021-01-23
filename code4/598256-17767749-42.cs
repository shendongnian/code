    public MyRequest Deserialize(string inboundXML)
    {
    	var ms = new MemoryStream(Encoding.Unicode.GetBytes(inboundXML));
    	var serializer = new DataContractSerializer(typeof(MyRequest));
    	var request = new MyRequest();
    	request = (MyRequest)serializer.ReadObject(ms);
    
    	return request;
    }
