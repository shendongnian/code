    public class ValidatingInformationRetriever : IInformationRetriever
    {
        private readonly IInformationRetriever _baseRetriever;
        private bool _validated;
        public ValidatingInformationRetriever(IInformationRetriever baseRetriever)
        {
            _baseRetriever = baseRetriever;
        }
        public void Foo()
        {
            if(!_validated)
            {
                Validate();
                _validated = true;
            }
            _baseRetriever.Foo();
        }
        private void Validate()
        {
            // ...
        }
    }
