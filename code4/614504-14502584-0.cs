	public static class FileMutexes
	{
		private static System.Collections.Generic.Dictionary<string, System.Threading.Mutex> mutexesInUse = new System.Collections.Generic.Dictionary<string, System.Threading.Mutex>();
		public static System.Threading.Mutex GetMutexForFile(string fileName)
		{
			if (!mutexesInUse.ContainsKey(fileName))
				mutexesInUse[fileName] = new System.Threading.Mutex();
			return mutexesInUse[fileName];
		}
	}
