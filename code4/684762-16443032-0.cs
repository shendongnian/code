    public abstract class ZooKeeperBase<TZooKeeper, TAnimal>
        where TZooKeeper : ZooKeeperBase<TZooKeeper, TAnimal>
        where TAnimal : Animal
    {
        internal string name;
        internal List<TAnimal> animalsFed = new List<TAnimal>();
    
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
    }
    
    public abstract class ExperiencedZooKeeperBase<TZooKeeper, TAnimal>
        : ZooKeeperBase<TZooKeeper, TAnimal>
        where TZooKeeper : ExperiencedZooKeeperBase<TZooKeeper, TAnimal>
        where TAnimal : Animal
    {
        internal List<TAnimal> animalsCured = new List<TAnimal>();
    
        // this method needs to be fluent
        public TZooKeeper CureAnimal(TAnimal animal)
        {
            animalsCured.Add(animal);
            return (TZooKeeper)this;
        }
    }
