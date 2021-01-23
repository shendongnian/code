	public static IObservable<string> Split(
               this IObservable<char> incomingCharacters, 
               char sep)
	{
		// Our "stop buffering" trigger will be the separators
		var onlySeparators = incomingCharacters
			.Where(c => c == sep);
			
		return incomingCharacters
			// buffer until we get a separator
			.Buffer(onlySeparators)
			// then return a new string from the buffered chars
			.Select(carr => new string(carr.ToArray()));		
	}
