    public sealed class UserValues
    {
        private readonly List<UserValue> values = new List<UserValue>();
        private readonly ReadOnlyCollection<UserValue> valuesView;
        public UserValues()
        {
            valuesView = values.AsReadOnly();
        }
        public ReadOnlyCollection<UserValues> Values { get { return valuesView; } }
    }
