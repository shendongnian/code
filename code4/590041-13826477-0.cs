    public class MyBlah
    {
    	public string Name;
    	public int Value1;
    	public int Value2;
    	public int Value3;
    }
    
    public class MyDTO
    {
    	public int Value1;
    	public int Value2;
    	public int Value3;
    }
    
    void Main()
    {
    	MyBlah o1 = new MyBlah
    	{
    		Name = "asdf",
    		Value1 = 2,
    		Value2 = 3,
    		Value3 = 4
    	};
    	
    	MyBlah o2 = new MyBlah
    	{
    		Name = "fdsa",
    		Value1 = 3,
    		Value2 = 4,
    		Value3 = 5
    	};
    	
    	MyBlah o3 = new MyBlah
    	{
    		Name = "HI",
    		Value1 = 3,
    		Value2 = 4,
    		Value3 = 5
    	};
    	
    	List<MyBlah> lst = new List<MyBlah>();
    	lst.Add(o1);
    	lst.Add(o2);
    	lst.Add(o3);
    	
    	IEnumerable<MyBlah> result = from o in lst
    								 orderby o.Name
    								 group o by new {o.Value1, o.Value2, o.Value3} into groupedO
    								 select new MyBlah
    								 {
    									 Value1 = groupedO.Key.Value1,
    									 Value2 = groupedO.Key.Value2,
    									 Value3 = groupedO.Key.Value3
    								 };
    								 
    	IEnumerable<MyDTO> resultDTO = from o in lst
    								   orderby o.Name
    								   group o by new {o.Value1, o.Value2, o.Value3} into groupedO
    								   select new MyDTO
    								   {
    									   Value1 = groupedO.Key.Value1,
    									   Value2 = groupedO.Key.Value2,
    									   Value3 = groupedO.Key.Value3
    								   };
    }
