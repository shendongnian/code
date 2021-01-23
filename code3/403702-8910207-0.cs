    interface INamedObject
    {
    	string Name { get; }
    }
    
    interface IRenamableObject : INamedObject
    {
    	new string Name { set; }
    }
    
    class SomeObject : INamedObject, IRenamableObject
    {
    	public string Name { get; set;  }
    }
 
    // usage:
    IRenamableObject obj = new SomeObject();
    obj.Name = "some name";
    Console.WriteLine((obj as INamedObject).Name);
