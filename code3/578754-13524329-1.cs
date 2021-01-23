    var serializer = new DataContractJsonSerializer(typeof(SuperObj));
    using (var stream = new MemoryStream())
    {
      serializer.WriteObject(stream, obj);
      var jsonString = Encoding.UTF8.GetString(stream.ToArray());
      Console.WriteLine(jsonString);
    }
