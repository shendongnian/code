	public static Dictionary<string, string> LoadActivityLookup(string filePath) {
		const int KEY_LENGTH = 10;
		var newLookup = new Dictionary<string, string>();
		string[] fileLines = File.ReadAllLines(filePath);
		foreach (string line in fileLines) {
			string key = line.Substring(0, KEY_LENGTH);
			string value = line.Substring(KEY_LENGTH);
			if (!newLookup.ContainsKey(key)) {
				newLookup.Add(key, value);
			}
		}
		return newLookup;
	}
