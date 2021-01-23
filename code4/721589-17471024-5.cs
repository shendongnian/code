    public class User : Entity, IPrint, IGenerate
    {
       public void Print()
       {
         // some code
         // here you could access Name property, because it is on base class Entity
       } 
    
       public void Generate()
       {
         // some code
       } 
    }
