    Dictionary<string, List<Entity>> baseDict = new Dictionary<string, List<Entity>>();
    
    List<Entity> tags = new List<Entity>();
    tags.Add(new Tag("2012"));
    tags.Add(new Tag("hello"));
    tags.Add(new Tag("lego"));
    
    List<Entity> properties = new List<Entity>();
    properties.Add(new Properties("Year"));
    properties.Add(new Properties("Phrase"));
    properties.Add(new Properties("Type"));
    
    baseDict.Add("Tags", tags);
    baseDict.Add("Properties", properties);
