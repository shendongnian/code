    public class Block
    {
    	public int ID { get; set; }
    	public List<string> BlockNames { get; set; }
    
    	public Block(int id, params string[] names)
    	{
    		ID = id;
    		BlockNames = new List<string>();
    		foreach (var item in names)
    		{
    			BlockNames.Add(item);
    		}
    	}
    }
