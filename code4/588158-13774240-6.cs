    private static IEnumerable<HtmlNode> GetElementsWithClass(HtmlDocument doc, String className) {
            
        return doc
            .Descendants()
            .Where( n => n.NodeType == NodeType.Element )
            .Where( e =>
                e.Name == "div" &&
                CheapClassListContains(
                    e.GetAttributeValue("class", ""),
                    className,
                    StringComparison.Ordinal
                )
            );
    }
    /// <summary>Performs optionally-whitespace-padded string search without new string allocations.</summary>
    /// <remarks>A regex might also work, but constructing a new regex every time this method is called would be expensive.</remarks>
    private static Boolean CheapClassListContains(String haystack, String needle, StringComparison comparison)
    {
    	if( String.Equals( haystack, needle, comparison ) ) return true;
    	Int32 idx = 0;
    	while( idx + needle.Length <= haystack.Length )
    	{
    		idx = haystack.IndexOf( needle, idx, comparison );
    		if( idx == -1 ) return false;
    
    		Int32 end = idx + needle.Length;
    
    		// Needle must be enclosed in whitespace or be at the start/end of string
    		Boolean validStart = idx == 0               || Char.IsWhiteSpace( haystack[idx - 1] );
    		Boolean validEnd   = end == haystack.Length || Char.IsWhiteSpace( haystack[end] );
    		if( validStart && validEnd ) return true;
    		
    		idx++;
    	}
    	return false;
    }
