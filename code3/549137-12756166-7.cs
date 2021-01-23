    public class AnimalRepositoryImplementation : AnimalRepository
    {
        public IEnumerable<Animal> GetAnimals()
        {
            return new DBContext().Animals;
        }
    }
