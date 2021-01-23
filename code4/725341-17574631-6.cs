    public abstract class Item
    {
        private readonly ISpecification<Character> _wearerSpecification;
        protected Item(ISpecification<Character> wearerSpecification)
        {
            _wearerSpecification = wearerSpecification;
        }
        public ISpecification<Character> WearerSpecification
        {
            get { return _wearerSpecification; }
        }
    }
