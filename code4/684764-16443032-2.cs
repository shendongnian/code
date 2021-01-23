    public abstract class ZooKeeperBase<TZooKeeper, TAnimal>
        where TZooKeeper : ZooKeeperBase<TZooKeeper, TAnimal>
        where TAnimal : Animal
    {
        private string name;
        private List<TAnimal> animalsFed = new List<TAnimal>();
        private TAnimal favoriteAnimal;
    
        public TZooKeeper Name(string name)
        {
            this.name = name;
            return (TZooKeeper)this;
        }
    
        public TZooKeeper FeedAnimal(TAnimal animal)
        {
            animalsFed.Add(animal);
            return (TZooKeeper)this;
        }
        public TZooKeeper Favorite(Func<TAnimal, bool> animalSelector)
        {
            favoriteAnimal = animalsFed.FirstOrDefault(animalSelector);
            return (TZooKeeper)this;
        }
    }
    
    public abstract class ExperiencedZooKeeperBase<TZooKeeper, TAnimal>
        : ZooKeeperBase<TZooKeeper, TAnimal>
        where TZooKeeper : ExperiencedZooKeeperBase<TZooKeeper, TAnimal>
        where TAnimal : Animal
    {
        private List<TAnimal> animalsCured = new List<TAnimal>();
    
        public TZooKeeper CureAnimal(TAnimal animal)
        {
            animalsCured.Add(animal);
            return (TZooKeeper)this;
        }
    }
