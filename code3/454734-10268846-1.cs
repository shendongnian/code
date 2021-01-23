     public object Clone()
    {
    	IO.MemoryStream mem = new IO.MemoryStream();
    	System.Runtime.Serialization.Formatters.Binary.BinaryFormatter form = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    	form.Serialize(mem, this);
    	mem.Position = 0;
    	return form.Deserialize(mem);
    	
    }
