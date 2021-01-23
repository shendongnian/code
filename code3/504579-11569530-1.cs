		private Dictionary<string, IEnumerable<string>> ParseValues(string providedValues)
		{
			Dictionary<string, IEnumerable<string>> parsedValues = new Dictionary<string, IEnumerable<string>>();
			string[] lines = providedValues.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries); //Your newline character here might differ, being '\r', '\n', '\r\n'...
			foreach (string line in lines)
			{
				string[] lineSplit = line.Split(':');
				string key = lineSplit[0].Trim();
				IEnumerable<string> values = lineSplit[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()); //Removing empty entries here will ensure you don't get an empty for the "Interest" line, where you have 'Hiking' followed by a comma, followed by nothing else
				parsedValues.Add(key, values);
			}
			return parsedValues;
		}
