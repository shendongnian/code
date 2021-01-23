    public static IEnumerable<int> GetMatches(string source, string test)
    {
       return from i in Enumerable.Range(0,test.Length - source.Length)
	      where IsValid(source, !test.Skip(i).Take(source.Length))
              select i;
    }
    public static bool IsValid(string source, IEnumerable<char> test) 
    {
       return test.Where((x,i) => source[i] != x).Skip(2).Any();
    }
