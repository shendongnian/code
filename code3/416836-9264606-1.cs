		protected string ReplaceUsingDictionary(string subject, Dictionary<string,string> pairs)
		{
			StringBuilder sb = new StringBuilder(subject);
			sb.Replace("{", "{{").Replace("}", "}}");
			int i=0;
			foreach (string key in pairs.Keys.ToArray())
			{
				sb.Replace(
					key.Replace("{", "{{").Replace("}", "}}"), 
					"{" + i + "}"
				);
				i++;
			}
			return string.Format(sb.ToString(), pairs.Values.ToArray());
		}
    // usage
    Dictionary<string, string> replacements = new Dictionary<string, string>();
    replacements["["] = "[[]";
    replacements["]"] = "[]]";
    string mystr = ReplaceWithDictionary("[HelloWorld]", replacements); // returns [[]HelloWorld[]]
    
