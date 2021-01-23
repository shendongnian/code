    public class MyObjectBuilder{
      // inject the repository
      public MyObjectBuilder(IMyObjectBuilderRepository repository) 
      
      private Property1 property1;
      public void SetProperty1(Property1 prop){}
      
      public MyObject GetMyObject(){
        MyObject result = new MyObject(); // optional to use constructor injection
        result.Property1 = this.property1;
        
        Property4Set property4 = new Property4Set();
        // based on this.property1, set the Property4Set object
        
        result.Property4 = property4;
        return result;
      }
    }
