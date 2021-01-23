    public class Foo
    {
    	public int Id { get; set; }
    
    	public string Name { get; set; }
    }
    
    public class Test
    {
    	private List<Foo> list = new List<Foo>();
    
    	public void Add(Foo foo)
    	{
    		this.list.Add(foo);
    	}
    
    	public Foo GetById(int id)
    	{
    		return this.list.FirstOrDefault(z => z.Id == id);
    	}
    }
    ....
    Test test = new Test();
    test.Add(new Foo { Id = 1, Name = "1" });
    test.Add(new Foo { Id = 2, Name = "2" });
    test.Add(new Foo { Id = 3, Name = "3" });
    
    Foo foo2 = test.GetById(2);
