       public interface FactoryObject
       {
              void Create();
              void Destroy();
       }
     
       public class Car:FactoryObject
       {
            public void Create()
            {
                 //TODO: Create my tyres and my petrol
                 //TODO: Create my fenders and body
            }
       }
    
       public class Bicycle:FactoryObject
       {
            public void Create()
            {
                 //TODO: Create my tyres but I do not need petrol
                 //TODO: Create my fenders but I have no body
            }
       }
    
       public class Factory
       {
            public FactoryObject GetFactoryObject(Type type)
            {
                 FactoryObject returnedObject = null;
                 if ( type is Car ) returnedObject = new Car();
                 elseif (type is Bicycle) returnedObject = new Bicycle();
                 if (returnedObject != null)
                      returnedObject.Create();
                 return returnedObject;
            }       
       }
