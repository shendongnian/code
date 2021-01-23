    static class StringExtension{
    		public static int WordCount( this String text, string searchTerm )
    		{
    			string[] source = text.Split( new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries );
    			var matchQuery = from word in source
    							 where word.ToLowerInvariant() == searchTerm.ToLowerInvariant()
    							 select word;
    			int wordCount = matchQuery.Count();
    			return wordCount;
    		}
    		public static int WordCount( this String text, string[] searchTerms ) {
    			int wordCount = 0;
    			foreach( string searchTerm in searchTerms ) {
    				wordCount += text.WordCount( searchTerm );
    			}
    			return wordCount;
    		}
    	}
