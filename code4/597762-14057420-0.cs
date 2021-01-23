    public class Cage : ICage
    {
        public Animal SomeAnimal { get; set; }
    
        IAnimal ICage.SomeAnimal
        {
            get { return SomeAnimal }
        }
    }
