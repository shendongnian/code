    [ElasticType(Name = "TestEntity", DisableAllField = true)]
    public class TestEntity
    {
    	public TestEntity(int id, string desc)
    	{
    		ID = id;
    		Description = desc;
    	}
    
    	public int ID { get; set; }
    
    	[ElasticProperty(Analyzer = "nospecialchars")]
    	public string Description { get; set; }
    }
