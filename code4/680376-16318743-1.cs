    public class MyObjectBuilder{
      // inject the repository
      public MyObjectBuilder(IMyObjectBuilderRepository repository) 
      
      private Property1 property1;
      public void SetProperty1(Property1 prop){}
      
      public MyObject GetMyObject(){
        MyObject result = new MyObject(); // optional to use constructor injection
        result.Property1 = this.property1;
        
        // based on this.property1, set the Property4Set object
        Property4Set property4 = repository.GetProperty4Set(this.property1);
        
        result.Property4 = property4;
        return result;
      }
    }
