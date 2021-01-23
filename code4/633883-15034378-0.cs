    var words = new List<string>() {"Hello","Hey","cat"};
	var filter = new List<string>() {"Cat"};
    // Perhaps a Except() here to match exact strings without substrings first?
	var filtered = words.Where(i=> !ContainsAny(i,filter)).AsParallel();    
    // You could experiment with AsParallel() and see 
    // if running the query parallel yields faster results on larger string[]
    public bool ContainsAny(string str, IEnumerable<string> values)
    {
       if (!string.IsNullOrEmpty(str) || values.Any())
       {
           foreach (string value in values)
           {
               if(str.ToLowerInvariant().Contains(value.ToLowerInvariant()))
                   return true;
           }
       }
       return false;
    }
