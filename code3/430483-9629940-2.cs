    public abstract class MainSession
    {
        private List<IAnimal> _animals;
        
        public IEnumerable<IAnimal> Animals {get { return _animals; }}
        
        proteced IAnimal CreateAnimal(string speciesName)
        {
            // Either use reflection to find the correct species,
            // or a simple switch like below:
            switch (speciesName)
            {
                case "tiger":
                    return new Tiger();
                    break;
            }
        }
    }
    
