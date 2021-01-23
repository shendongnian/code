    IEnumerable<string> Replaces(string source)
    {
        var rx = new Regex(@"\w+m", RegexOptions.IgnoreCase); // match words ending with 'm'
        var result = new List<string>(); 
        rx.Replace(source, m => { result.Add(m.ToString().ToUpper()); return m.ToString(); });
        return result;
    }
		List<string> GetReplacements(List<string> sources) {
		    var rx = new Regex(@"\w+m", RegexOptions.IgnoreCase); // match words ending with 'm'.
			var replacements = new List<string>(sources.Count);   // no need to allocate more space than needed.
			foreach(string source in sources) 
				// for each string in sources that matches 'rx', add the ToUpper() version to the result and replace 'source' with itself.
				rx.Replace(source, m  => {replacements.Add(m.ToString().ToUpper()); return m.ToString(); });
			return replacements;
		}
		List<string> GetReplacements2(List<string> sources) {
		    var rx = new Regex(@"\w+m", RegexOptions.IgnoreCase); // match words ending with 'm'.
			var replacements = new List<string>(sources.Count);   // no need to allocate more space than needed.
			foreach(string source in sources) {
				var m = rx.Match(source);                         // do one rx match
				if (m.Success)                                    // if successfull
					replacements.Add(m.ToString().ToUpper());     // add to result.
			}
			return replacements;
		}
