	public static class RepositoryManager
	{
		public delegate void Reload();
		private static List<Reload> FRepositories = new List<Reload>();
		public static void Register(Reload repository)
		{
			lock (FRepositories)
			{
				FRepositories.Add(repository);
			}
			repository();
		}
		public static void ReloadAll()
		{
			List<Reload> list;
			lock (FRepositories)
			{
				list = new List<Reload>(FRepositories);
			}
			foreach (Reload repository in list)
				repository();
		}
	}
