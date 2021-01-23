	public static IObservable<string> Split(
              this IObservable<char> incomingCharacters, 
              char sep)
	{
		// Share a single subscription
		var oneSource = incomingCharacters.Publish().RefCount();
		
		// Our "stop buffering" trigger will be the separators
		var onlySeparators = oneSource
			.Where(c => c == sep);
			
		return oneSource
			// buffer until we get a separator
			.Buffer(onlySeparators)
			// then return a new string from the buffered chars
			.Select(carr => new string(carr.ToArray()));		
	}
