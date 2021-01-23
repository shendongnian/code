    public static class Factory {
       public static IActivity<someType> Get(this someType self){
              //stuff specific to someType
       }
    
       public static IActivity<someOtherType> Get(someOtherType self){
              //stuff specific to someOtherType
       }
     
       public static T Creator<T>(){
            return null;
       }
       
    }
