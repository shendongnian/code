    public class MyClass
    {
       private static MyConfigurationData;
       private static MyClass()
       {
         //Initialize Configuration Data
           MyConfigurationData = ...
         //This operation is bit slow as it needs to query the DB to retreive configuration data
       }
       public static MyMethodWhichNeedsConfigurationData()
       {          //Multilple threads can call this method
          var config = MyConfigurationData;
       }
    }
