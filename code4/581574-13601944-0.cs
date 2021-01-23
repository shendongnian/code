    public class Animal
    { 
       public enum AnimalType
       {
         CowType,
         HorseType
       }
    
    
       ....
       public Animal Create(AnimalType type)
       {
         Animal result = null;
          switch (type)
          {
           case HorseType: result = new Horse();
           case CowType : ....   
          }
         return result;
       }
    }
    
    
