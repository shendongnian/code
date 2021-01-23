    byte[] content = File.ReadAllBytes(path);
    var ms = new MemoryStream(content);
    List<float> result = new List<float>()
    
    using(BinaryReader br = new BinaryReader(ms))
    {
	    result.Add(br.ReadSingle());
    }
