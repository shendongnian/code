        static void Main(string[] args)
		{
			string csv = "Hello,1,3.5,25,\"speech marks\",'inverted commas'\r\nWorld,2,4,60,\"again, more speech marks\",'something else in inverted commas, with a comma'";
			// General way to create grouping constructs which are valid 'text' fields
			string p = "{0}([^{0}]*){0}"; // match group '([^']*)' (inverted commas) or \"([^\"]*)\" (speech marks)
			string c = "(?<={0}|^)([^{0}]*)(?:{0}|$)"; // commas or other delimiter group (?<=,|^)([^,]*)(?:,|$)
			char delimiter = ','; // this can be whatever delimiter you like
			string p1 = String.Format(p, "\""); // speechmarks group (0)
			string p2 = String.Format(p, "'"); // inverted comma group (1)
			string c1 = String.Format(c, delimiter); // delimiter group (2)
			/*
			 * The first capture group will be speech marks ie. "some text, "
			 * The second capture group will be inverted commas ie. 'this text'
			 * The third is everything else seperated by commas i.e. this,and,this will be [this][and][this]
			 * You can extend this to customise delimiters that represent text where a comma between is a valid entry eg. "this text, complete with a pause, is perfectly valid"
			 * 
			 * */
			//string pattern = "\"([^\"]*)\"|'([^']*)'|(?<=,|^)([^,]*)(?:,|$)";
			string pattern = String.Format("{0}|{1}|{2}", new object[] { p1, p2, c1 }); // The actual pattern to match based on groups
			string text = csv;
			
			// If you're reading from a text file then this will do the trick.  Uses the ReadToEnd() to put the whole file to a string.
			//using (TextReader tr = new StreamReader("PATH TO MY CSV FILE", Encoding.ASCII))
			//{
			//    text = tr.ReadToEnd(); // just read the whole stream
			//}
			
			string[] lines = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); // if you have a blank line just remove it?
			Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase); // compile for speed
			List<object> rowsOfColumns = new List<object>();
			foreach (string row in lines)
			{
				List<string> columns = new List<string>();
				// Find matches.
				MatchCollection matches = regex.Matches(row);
				foreach (Match match in matches)
				{
					for (int ii = 0; ii < match.Groups.Count; ii++)
					{
						if (match.Groups[ii].Success) // ignore things that don't match
						{
							columns.Add(match.Groups[ii].Value.TrimEnd(new char[] { delimiter })); // strip the delimiter
							break;
						}
					}
				}
				// Do something with your columns here (add to List for example)
				rowsOfColumns.Add(columns);
			}
		}
