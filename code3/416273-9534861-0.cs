    using System;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    public abstract class Animal
    {
        public int Weight { get; set; }    
    }
    public class Cat : Animal
    {
        public int FurLength { get; set; }    
    }
    public class Fish : Animal
    {
        public int ScalesCount { get; set; }    
    }
    public class AnimalFarm
    {
        [XmlElement(typeof(Cat))]
        [XmlElement(typeof(Fish))]
        public List<Animal> Animals { get; set; }
        public AnimalFarm()
        {
            Animals = new List<Animal>();
        }
    }
    public class Program
    {
        public static void Main()
        {
            AnimalFarm animalFarm = new AnimalFarm();
            animalFarm.Animals.Add(new Cat() { Weight = 4000, FurLength = 3 });
            animalFarm.Animals.Add(new Fish() { Weight = 200, ScalesCount = 99 });
            XmlSerializer serializer = new XmlSerializer(typeof(AnimalFarm));
            serializer.Serialize(Console.Out, animalFarm);
        }
    }
