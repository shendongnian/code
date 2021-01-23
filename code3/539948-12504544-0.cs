    public class ClassA 
    {
       public object PropC { get; private set; }        
       private ClassA (){};
       public Create (object propC)
       {
          return new ClassA{ PropC = propC };
       }
     }
 
 
