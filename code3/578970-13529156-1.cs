	public String ReadFile(String filename)
	{
		if (!File.Exists(filename))
		{
			// now what? throw new FileNotFoundException()? return null?
		}
		
		// Will throw FileNotFoundException if not exists, can happen (race condition, file gets deleted after the `if` above)
		using (var reader = new StreamReader(filename))
		{
			return reader.ReadToEnd();
		}
	}
