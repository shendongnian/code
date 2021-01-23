    var tdp = new DerivedObject("Test");
	using (var ms  = new MemoryStream())
	{
		Serializer.Serialize(ms,tdp);
		//was missing this line
		ms.Seek(0, SeekOrigin.Begin);
		var tdp2 = Serializer.Deserialize<DerivedObject>(ms);
	}
