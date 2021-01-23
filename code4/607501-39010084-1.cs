    public class MyClass
    {
    	public int ID { get; set; }
    	public int Name { get; set; }
    }
    
    public static void UpdateStuff(this MyClass target, int id, string name)
    {
    	target.ID = id;
    	target.Name = name;
    }
    static void Main(string[] args)
    {
        var someObj = new MyClass();    
        
    	someObj.UpdateStuff(301, "RandomUser002");
    }
