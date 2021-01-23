    private Dictionary<String,List<Int32>> _index = new Dictionary<String,List<Int32>>();
    
    /// <summary>Populates an index of words in a text file. Takes O(n) where n is the size of the input text file.</summary>
    public void BuildIndex(String fileName) {
    
        using(Stream inputTextFile = OpenFile(...)) {
        
            int currentPosition = 0;
            foreach(String word in GetWords(inputTextFile)) {
                
                word = word.ToUpperInvariant();
                if( !_index.ContainsKey( word ) ) _index.Add( word, new List<Int32>() );
                _index[word].Add( currentPosition );
                
                currentPosition = inputTextFile.Position;
            }
        }
    }
    
    /// <summary>Searches the text file (via its index) if the specified string (in its entirety) exists in the document. If so, it returns the position in the document where the string starts. Otherwise it returns -1. Lookup time is O(1) on the size of the input text file, and O(n) for the length of the query string.</summary>
    public Int32 SearchIndex(String query) {
        
        String[] terms = query.Split(' ');
        
        Int32 startingPosition = -1;
        Int32 currentPosition = -1;
        Boolean first = true;
        foreach(String term in terms) {
            term = term.ToUpperInvariant();
            
            if( first ) {
                if( !_index.Contains( term ) ) return -1;
                startingPosition = _index[term][0];
            } else {
                
                if( !ContainsTerm( term, ++currentPosition ) ) return -1;
            }
            
            first = false;
        }
        
        return startingPosition;
    }
    /// <summary>Indicates if the specified term exists at the specified position.</summary>
    private Boolean ContainsTerm(String term, Int32 expectedPosition) {
        
        if( !_index.ContainsKey(term) ) return false;
        List<Int32> positions = _index[term];
        foreach(Int32 pos in positions) {
            
            if( pos == expectedPosition ) return true;
        }
        return false;
    }
    
