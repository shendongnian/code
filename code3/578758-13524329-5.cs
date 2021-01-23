    var serializer = new DataContractJsonSerializer(typeof(SuperObj));
    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
    {
      var obj2 = (SuperObj)serializer.ReadObject(stream);
      Console.WriteLine("SuperObj");
      Console.WriteLine(obj2.Foo);
      Console.WriteLine(obj2.Bar);
      Console.WriteLine(obj2.Baz);
      Console.WriteLine(obj2.Qux);
    }
