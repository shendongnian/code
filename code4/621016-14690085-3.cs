    public class SetDifference<T>
    {
        public SetDifference(List<T> list, IEnumerable<T> additionalObjects,
                IEnumerable<T> missingObjects)
        {
            List = list;
            AdditionalObjects = additionalObjects;
            MissingObjects = missingObjects;
        }
        public List<T> List { get; private set; }
        public IEnumerable<T> AdditionalObjects { get; private set; }
        public IEnumerable<T> MissingObjects { get; private set; }
    }
