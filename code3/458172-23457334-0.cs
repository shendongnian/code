    string json= string.Empty;
    using (var streamReader = new StreamReader(response.GetResponseStream(), true))
            {
                json= new JavaScriptSerializer().Deserialize<string>(streamReader.ReadToEnd());
            }
    //To serialize to your object type...
    MyType myType;
    using (var memoryStream = new MemoryStream())
             {
                byte[] jsonBytes = Encoding.UTF8.GetBytes(@json);
                memoryStream.Write(jsonBytes, 0, jsonBytes.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);
                using (var jsonReader = JsonReaderWriterFactory.CreateJsonReader(memoryStream, Encoding.UTF8,          XmlDictionaryReaderQuotas.Max, null))
                {
                    var serializer = new DataContractJsonSerializer(typeof(MyType));
                    returnValue = (MyType)serializer.ReadObject(jsonReader);
                }
            }
            return returnValue;
