    string s;
    	using (StreamReader file = File.OpenText(basePath + "jsontxt"))
    	{
    		Byte secretByte = 125;
    		s = file.ReadToEnd();
    		Byte[] byteString = Encoding.UTF8.GetBytes(s);
    		foreach(Byte b in byteString){
    			b ^= secretByte;
    		}
    	}
    	//here save stream
