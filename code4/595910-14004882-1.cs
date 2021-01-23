    public interface IPackable
    {
        public float Weight { get; set; }
    }
    public interface IPacker
    {
        // Returns a list of packages represented by lists of fruits.
        List<List<Fruit>> GetPackages(IEnumerable<Fruit> fruits, float maxPackageWeight)
        {
            ...
            foreach (Fruit fruit in fruits) {
                var packable = fruit as IPackable;
                if (packable != null) {
                    ...
                }
            }
            ...
        }
    }
