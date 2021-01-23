    public class NamedObject
    {
        public string Name { get { return _getName(); } }
        private Func<string> _getName;
        public NamedObject(Func<string> getName)
        {
            _getName = getName;
        }
    }
