    MyReturnObject retVal = new MyReturnObject(myParam)
    var serializer = new DataContractSerializer(retVal.GetType());
    
    using (var xmlData = new StringWriter())
    using (var writer = XmlTextWriter.Create(xmlData))
    {
    	serializer.WriteObject(writer, retVal);
    	Console.WriteLine(xmlData.ToString());
    } 
