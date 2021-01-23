    public class Foo
    {
        private readonly List<Lazy<IAnimal, Type>> _animals;
        public Foo(List<Lazy<IAnimal, Type>> animals)
        {
            _animals = animals;
        }
        public void Bark()
        {
            var dog = _animals.First(p => p.Metadata == typeof(Dog)).Value;
        }
    }
