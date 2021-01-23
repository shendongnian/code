    public class Config
    {
       private string name;
       private IList<Element> elements = new List<Element>();
       public IList<Element> GetElements {get {return this.elements;}}
       public Config Name(string name)
       {
    	  this.name = name;
    	  return this;
       }
    
       public Config Elements(IEnumerable<Element> list)
       {
       		foreach ( var element in list)
       			elements.Add(element);
    		return this;
       }
       
       public Config Elements(params Element[] list)
       {
       		foreach ( var element in list)
       			elements.Add(element);
    		return this;
       }
       
       public Config Elements(params Expression<Func<Element>>[] funcs)
       {
    		foreach (var func in funcs )
    			elements.Add(func.Compile()());
    		return this;
       }
       
       public Config Elements(params Expression<Func<IEnumerable<Element>>>[] funcs)
       {
    		foreach (var func in funcs )
    			foreach ( var element in func.Compile()())
    				elements.Add(element);
    		return this;
       }
    
       public class Element
       {
    	  public string Name { get; set; }
    	  public int Height { get; set; }	  
    	  public Element() {}
    	  public Element(string name)
    	  {
    	  	 this.Name = name;
    	  }	 
    	  public Element AddHeight(int height)
    	  {
    	  	  this.Height = height;
    		  return this;
    	  }
    	  public static Element AddName(string name)
    	  {
    	  	return new Element(name);
    	  }
       }
    }
