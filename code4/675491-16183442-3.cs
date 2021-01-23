    public class Province
    {
    	public string Name {get;set}
    }
    
    public class Country
    {
    	public string ShortName {get;set}
    	public string LongName {get;set}
    	public List<Province> Provinces {get;set}
    }
    
    public class UIObject
    {
    	public List<Country> Countries {get;set;}
    }
