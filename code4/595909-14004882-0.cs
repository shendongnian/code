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
            foreach (IPackable fruit in fruits.OfType<IPackable>()) {
                ...
            }
            ...
        }
    }
