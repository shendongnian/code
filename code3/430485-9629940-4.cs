    public abstract class MainSession
    {
        private List<IAnimal> _animals;
        
        public IEnumerable<IAnimal> Animals {get { return _animals; }}
        
        proteced void AddAnimal(IAnimal animal)
        {
            _animals.Add(animal);
        }
    }
    public class TypeA : MainSession
    {
        public TypeA()
        {
            AddAnimal(new Tiger());
        }
    }
    public class TypeB : MainSession
    {
        public TypeB()
        {
            AddAnimal(new Leopard());
        }
    }
    
