    private class Test
    {
    	public DateTime RequestDate { get; set; }
    
    	public string Name { get; set; }
    }
    
    private static void Main(string[] args)
    {
    	var list = new List<Test>
    	{
    		new Test
    		{
    			RequestDate = new DateTime(2012, 1, 1),
    			Name = "test"
    		},
    		new Test
    		{
    			RequestDate = new DateTime(2013, 1, 1),
    			Name = "a_test"
    		},
    	};
    
    	string mySort = "RequestDate";
    	list.Sort((x, y) =>
    		{
    			// Gets the property that match the name of the variable
    			var prop = typeof(Test).GetProperty(mySort);
    
    			var leftVal = (IComparable)prop.GetValue(x, null);
    			var rightVal = (IComparable)prop.GetValue(y, null);
    
    			return leftVal.CompareTo(rightVal);
    		});
    
    	Console.Read();
    }
