	void EnumerateDictionaryByOrderedKey(IDictionary dictionary) {
		//despite the name, this is more a dictionary than a list
		var sorted = new SortedList(dictionary);
		
		foreach (DictionaryEntry entry in sorted) {
			//do something with Entry.Key and Entry.Value
		}
	}
