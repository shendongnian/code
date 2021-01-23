    public class Foo
    {
    	public int ID { get; set; }
    	publi string Name { get; set; }
    }
    
    public class Bar
    {
    	public int ID { get; set; }
    	publi string Name { get; set; }
    }
    
    public class  MainClass
    {
    	IDataStore _dstore;
    	public void Main()
    	{
    		_dstore = new SqlServerDataStore("my_connection_string")//create data store
    		
    		InsertObject(new Foo());
    		InsertObject(new Bar());
    	}
    	
    	public void InsertObject(object o)
    	{
    		//this will assume the table it belongs to is the type name + an s
                //you can override the table name behavior as well
    		_dstore.InsertObject(o);
    	}
    }
