    public sealed class ZooList : List<Animal> // I believe you need Animal, not Type
    {
        // ... some implementations ...
        
        public override sealed void Add(Animal animal)
        {
            if (!animal.IsCagable)
                // Prevent from adding.
        }
    }
