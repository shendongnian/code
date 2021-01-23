    public class PropertyViewModel  
    {  
      public List<Photo> Photos { get; private set; }  
      public PropertyViewModel()  
      {  
        ...  
        Photos = new List<Photo>();  
        ...  
      }  
    }
