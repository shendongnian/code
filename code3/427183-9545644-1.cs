    void Main()
    {
    	 IEnumerable<TextBox> items = new List<TextBox>{
    		new TextBox{ Name = "One" },
    		new TextBox{ Name = "Two" },
    		new TextBox{ Name = "Three" },
    		new TextBox{ Name = "Four" },
    	};
    	
    	items.Single (i => i.Name == "One").Dump();
    }
    
    class TextBox
    {
    	public string Name {get;set;}
    }
