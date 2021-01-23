    void Main()
    {
    	var groups = new[] { "a", "a", "b", "b", "c", "c" }.GroupBy(s => s, new BadComparer())
    	    .Select(g => string.Join(",", g))
    		.ToArray();
    	Console.WriteLine(string.Join(Environment.NewLine, groups));
        // this prints:
        // a,a
        // b,b
        // c,c      
    }
    
    public class BadComparer : IEqualityComparer<string> {
        public bool Equals(string a, string b) { return a == b; }
    	public int GetHashCode(string s) { return 0; }
    }
