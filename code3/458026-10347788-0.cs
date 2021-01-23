    public class Config
    {
       private string name;
       private IList<Element> elements = new List<Element>();
    
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
    
       public class Element
       {
    	  public string Name { get; set; }
    	  public int Height { get; set; }
       }
    }
