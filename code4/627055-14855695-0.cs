    public string[] FindNameByLength(int minimumCharNumber)
    {
    	using (Database db = new Database())
    	{
    		var query = from u in db.Users
    					where u.FullName.Length > minimumCharNumber
    					select u.FullName;
    
    		string[] namesLength;
    		int counter;
    
    		foreach (var s in query)
    		{
    			namesLength.Concat(new[] { s });
    		}
    
    		return namesLength;
    	}
    }
