	using(var cryptoStream = 
          new CryptoStream(fileStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
	{				
		using(var reader = new StreamReader(cryptoStream))
		{
			var s = reader.ReadToEnd().TrimEnd(new char[]{'\0'});
			
			using(var stream = new MemoryStream(Encoding.ASCII.GetBytes(s)))
			{
				o = (t)serializer.ReadObject(stream);
			}
		}
	}
