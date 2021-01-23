	static void Throw ()
	{
		try {
			throw new Exception ("oups");
		} catch (Exception e) {
			Console.WriteLine (e);
		}
	}
