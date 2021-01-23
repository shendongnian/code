	public static Dictionary<string, string> LoadActivityLookup(string filePath) {
		const int KEY_LENGTH = 10;
		var newLookup = new Dictionary<string, string>();
		foreach (string line in File.ReadAllLines(filePath)) {
			if (line.Length < KEY_LENGTH) continue;
			string key = line.Substring(0, KEY_LENGTH);
			if (!newLookup.ContainsKey(key)) {
				string value = line.Substring(KEY_LENGTH);
				newLookup.Add(key, value);
			}
		}
		return newLookup;
	}
