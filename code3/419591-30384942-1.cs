    public interface IDependencyOfData
    {
        string Value { get; }
    }
    public class SpecificDataDependency : IDependencyOfData
    {
        private static int _seq;
        private int _id;
        public SpecificDataDependency()
        {
            _id = Interlocked.Increment(ref _seq);
        }
        public string Value { get { return "Some value " + _id; } }
    }
    public class Data
    {
        private readonly IDependencyOfData _dep;
        public Data(IDependencyOfData dataDependency)
        {
            this._dep = dataDependency;
            this.ConstructedAt = DateTime.UtcNow;
        }
        public DateTime ConstructedAt { get; private set; }
        public string DependencyValue 
        {
            get { return _dep != null ? _dep.Value : null; }
        }
    }
