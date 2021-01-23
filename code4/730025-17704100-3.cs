    [Flags] public enum AnimalType { Carnivorous = 1, Herbivorous = 2, Ominovorous = 3 }
    public class Animal
    {
        public AnimalType Type { get; set; }
        public string Category { get; set; }
        //all the other members that Herbivorous + Carnivorous share,
        //so pretty much all of them really.
    }
