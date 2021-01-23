    public List<Book> Shoot()
    {
    	var authors = new Dictionary<string, int>();
    	foreach(var b in books) 
        {
    		if(authors.ContainsKey(b.Author))
    			authors[b.Author] ++;
    		else
    			authors.Add(b.Author, 1);
    	}
    	
    	foreach(var b in books) 
        {
    		if(authors[b.Author] == 1)
    			yield return b;
    	}
    }
