	public static class GitRevisionProvider
	{
		public static string GetHash()
		{
			using(var stream = Assembly.GetExecutingAssembly()
										.GetManifestResourceStream(
										"DEFAULT_NAMESPACE" + "." + "revision.txt"))
			using(var reader = new StreamReader(stream))
			{
				return reader.ReadLine();
			}
		}
	}
