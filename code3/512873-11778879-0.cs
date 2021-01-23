		private static Dictionary<string, int> arguments = new Dictionary<string, int>(5);
		public int Option(string arg)
		{
			arguments.Add("Max", 0);
			arguments.Add("Med", 1000);
			arguments.Add("Min", 2000);
			int value;
			if (arguments.TryGetValue(arg.Replace("/:", string.Empty), out value))
				return value;
			//default
			return 0;
		}
