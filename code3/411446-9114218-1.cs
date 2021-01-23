    public class Range
    {
    	public int Left { get; set; }	
    	public int Right { get; set; }
    	public string Title { get; set; }
    
    	public Range(int left, int right, string title) { Left = left; Right = right; Title = title; }
    
    	public bool Contains(int x) { return Left <= x && x <= Right; }
    }
    
    void Main()
    {
    	var x = 15;
    	
    	var ranges = new[] {
    		new Range(0, 10, "A"),
    		new Range(11, 20, "B")
    	};
    	
    	var foo = ranges.Where(r => r.Contains(x)).Single();
    	
    	Console.Write(foo.Title);
    }
