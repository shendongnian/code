    public class AnimalRepositoryImplementation : AnimalRepository
    {
        private IList<Animal> animals = new List<Animal>();
        public IEnumerable<Animal> GetAnimals()
        {
            return animals;
        }
    }
