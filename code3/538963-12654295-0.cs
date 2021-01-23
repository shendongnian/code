    public class SymbolGenerator
    {
        private readonly string[] _symbols = { "A", "B", "C", ... };
        private readonly IEnumerator<string> _enumerator;
        public SymbolGenerator()
        {
            _enumerator = EnumerateSymbols().GetEnumerator();
        }
        public string GetNextSymbol()
        {
            _enumerator.MoveNext();
            return _enumerator.Current;
        }
        private IEnumerable<string> EnumerateSymbols()
        {
            // (unchanged)
        }
    }
