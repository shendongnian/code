    class Order
    {
    	public string Size {get; set;}
    	public string Gender {get; set;}
    	public string Colour {get; set;}
    	public string Type {get; set;}
    	
        // List of "searchable" properties
    	public IEnumerable<string> GetTags()
    	{
    		return new []{Size, Gender, Colour, Type};
    	}
    }
