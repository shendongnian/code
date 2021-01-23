    abstract class SymbolProcessor
    {
        protected ISymbolRequest _Request;
        public SymbolProcessor(ISymbolRequest request)
        {
            _Request = request;
        }
        public abstract void GetSymbolData();
        public abstract void PostProcessSymbolData();
    }
