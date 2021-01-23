    bool equal = Enumerable.SequenceEqual(a.nestedPackages, b.nestedPackages,
        new ModelElementComparer());
    public class ModelElementComparer : IEqualityComparer<ModelElement>
    {
        public bool Equals(ModelElement x, ModelElement y)
        {
            return x.id == y.id;
        }
        public int GetHashCode(ModelElement obj)
        {
            return x.id;
        }
    }
