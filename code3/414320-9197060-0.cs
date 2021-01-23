    MyReturnObject retVal = new MyReturnObject(myParam)
    var serializer = new DataContractSerializer(retVal.GetType());
    
    using (var xmlData = new System.IO.StringWriter())
    using (var writer = new System.Xml.XmlTextWriter(xmlData))
    {
    	serializer.WriteObject(writer, retVal);
    	Console.WriteLine(xmlData.ToString());
    } 
