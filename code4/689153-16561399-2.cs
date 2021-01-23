    var serializer = new DataContractJsonSerializer(typeof(workspacename));
    using (var stream = new MemoryStream())
    {
     var asBytes = Encoding.UTF8.GetBytes(jsonObjectString);
     stream.Write(asBytes, 0, asBytes.Length);
     stream.Flush();
     stream.Seek(0, SeekOrigin.Begin);
     var yourDeserializedWorkspacename= (workspacename)serializer.ReadObject(stream);
    }
