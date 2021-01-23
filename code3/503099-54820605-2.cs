	////////////////////////////////////////////////////////////////////////////////////////////////////////
	///////////// Search for a string/s inside 'text' using the 'find' parameter, and replace with a string/s using the replace parameter
	// ✪ represents multiple wildcard characters (non-greedy)
	// ★ represents a single wildcard character
	public StringBuilder wildcard(StringBuilder text, string find, string replace, bool caseSensitive = false)
	{
		return wildcard(text, new string[] { find }, new string[] { replace }, caseSensitive);
	}
	public StringBuilder wildcard(StringBuilder text, string[] find, string[] replace, bool caseSensitive = false)
	{
		if (text.Length == 0) return text;			// Degenerate case
		StringBuilder sb = new StringBuilder();		// The new adjusted string with replacements
		for (int i = 0; i < text.Length; i++)	{	// Go through every letter of the original large text
			bool foundMatch = false;				// Assume match hasn't been found to begin with
			for(int q=0; q< find.Length; q++) {		// Go through each query in turn
				if (find[q].Length == 0) continue;	// Ignore empty queries
				int f = 0;	int g = 0;				// Query cursor and text cursor
				bool multiWild = false;				// multiWild is ✪ symbol which represents many wildcard characters
				int multiWildPosition = 0;			
			
				while(true)	{						// Loop through query characters
					if (f >= find[q].Length || (i + g) >= text.Length) break;		// Bounds checking
					char cf = find[q][f];											// Character in the query (f is the offset)
					char cg = text[i + g];											// Character in the text (g is the offset)
					if (!caseSensitive) cg = char.ToLowerInvariant(cg);
					if (cf != '★' && cf != '✪' && cg != cf && !multiWild) break;		// Break search, and thus no match is found
					if (cf == '✪') { multiWild = true; multiWildPosition = f; f++; continue; }				// Multi-char wildcard activated. Move query cursor, and reloop
					if (multiWild && cg != cf && cf != '★') { f = multiWildPosition + 1; g++; continue; }	// Match since MultiWild has failed, so return query cursor to MultiWild position
					f++; g++;															// Reaching here means that a single character was matched, so move both query and text cursor along one
				}
				if (f == find[q].Length) {			// If true, query cursor has reached the end of the query, so a match has been found!!!
					sb.Append(replace[q]);			// Append replacement
					foundMatch = true;
					if (find[q][f - 1] == '✪') { i = text.Length; break; }		// If the MultiWild is the last char in the query, then the rest of the string is a match, and so close off
					i += g - 1;													// Move text cursor along by the amount equivalent to its found match
				}
			}
			if (!foundMatch) sb.Append(text[i]);	// If a match wasn't found at that point in the text, then just append the original character
		}
		return sb;
	}
