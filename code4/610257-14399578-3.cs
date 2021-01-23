    static void Main()
    {
        NaturalFood food = GetSomeFood(); // At this point, we don't know the actual type
        food.SomeMethodInBaseClass(); // ok
     
    }
    
    static NaturalFood GetSomeFood()
    {
         if(somecondition) {
             return new Fruits();
         } 
         else{
             return new Vegetables();
         }
    }
    public abstract class NaturalFood
    {
         public abstract void SomeMethodInBaseClass();
    }
    
    public class Fruits : NaturalFood 
    {       
       public override void SomeMethodInBaseClass(){
            Console.WriteLine("I'm a fruit");
        }
    }
    
    public class Vegetables : NaturalFood
    {    
        public override void SomeMethodInBaseClass(){
             Console.WriteLine("I'm a vegetable");
        }   
    }
