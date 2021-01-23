    public interface IAnimal{
       Fur Fur{ get; set; }
       bool CanBark { get; set;}
    }
    
    public class Dog : IAnimal {
       public Fur Fur{ get; set; }
       public bool CanBark { get; set;}
    }
    
    public class Cat: IAnimal {
       public Fur Fur{ get; set; }
       public bool CanBark { get; set;}
    }
    public class Fur{
        public string Color {get;set;}
        public int Length {get;set}
    }
