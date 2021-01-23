    public class Animal { }
    public class Cat : Animal { }
    public class Wolf : Animal { }
    
    public class Baby
    {
        public List<Animal> ScaryAnimalsList { get; private set; }
    
        public Baby()
        {
            ScaryAnimalsList = new List<Animal>();
        }
    
        public void AddAnimalToScaryList(Animal animal)
        {
            ScaryAnimalsList.Add(animal);
        }
    
        public void RemoveAnimalFromScaryList(Animal animal)
        {
            if (ScaryAnimalsList.Contains(animal))
                ScaryAnimalsList.Remove(animal);
        }
    
        public bool IsAffraidOf(Animal animal)
        {
            return ScaryAnimalsList.Contains(animal);
        }
    }
        
