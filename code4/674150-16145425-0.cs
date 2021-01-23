	public string Serialize(object o)
    {
      DataContractSerializer ser = new DataContractSerializer(o.GetType());
      using (var ms = new MemoryStream())
      {
        ser.WriteObject(ms, o);
        return Encoding.Default.GetString(ms.ToArray());
      }
    }
	[Test]
	public void ShouldSerializeDictionaryCorrectlyAndDeserialize()
	{
	  MyDictionary dict = new MyDictionary();
	  dict["message1"] = "hello";
	  dict["message2"] = "world";
	  var s = Serialize(dict);
	  Assert.That(s, Is.StringStarting("<MyDictionary"));
	}
