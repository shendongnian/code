    public class BaseClass 
    {
        private readonly Lazy<List<string>> _someValues;
        protected List<string> SomeValues => _someValues.Value;
    }
