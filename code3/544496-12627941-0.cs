		private static IEnumerable<object> ParseKeys(string keyString)
		{
			IEnumerable<string> keyStrings = keyString.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries); // Use this construction to enable splitting on multiple characters
			List<object> keys = new List<object>();
			foreach (var key in keyStrings)
			{
				var type = Type.GetType(key.Split("|")[0]);
				var value = key.Split("|")[1];
				var data = Convert.ChangeType(value, type);
				keys.Add(data);
			}
			return keys;
		}
