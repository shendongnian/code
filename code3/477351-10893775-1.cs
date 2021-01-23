    public class Animal {
       public static Animal Otter;
       public static Animal Narwhal;
       // returns one of the static objects
       public static Animal GetAnimalById(int id) {...}
       // this is here only for serialization,
       // also it's the only thing that needs to be serialized
       public int ID { get; set; } 
       public string Name { get; set; }
       public double Weight { get; set; }
       public Habitat Habitat { get; set; }
    
       public void Swim();
    }
