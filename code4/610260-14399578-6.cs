    public enum NaturalFoodType {
        Unknown = 0,
        Apple= 1,
        Banana = 2,
        Potatoe = 3,
        Cucumber = 4
    }
    public abstract class NaturalFood
    {
         public abstract void SomeMethodInBaseClass();
         public abstract IEnumerable<NaturalFoodType> AcceptedFoodType { get; }
         public bool IsValid(NaturalFoodType type){
              return AcceptedFootType.Contains(type);
         }
    }
    
    public class Fruits : NaturalFood 
    {       
        public override void SomeMethodInBaseClass(){
            Console.WriteLine("I'm a fruit");
        }
        public override NaturalFoodType {
            get {
                 yield return NaturalFoodType.Apple;
                 yield return NaturalFoodType.Banana;
            }
        }
    }
    
    public class Vegetables : NaturalFood
    {    
        public override void SomeMethodInBaseClass(){
             Console.WriteLine("I'm a vegetable");
        } 
        public override NaturalFoodType {
            get {
                 yield return NaturalFoodType.Potatoe;
                 yield return NaturalFoodType.Cucumber;
            }
        }  
    }
