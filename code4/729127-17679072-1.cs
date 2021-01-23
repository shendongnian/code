        private readonly Dictionary<ExcelCellIdentifier, int> allInfoByIdentifier =
            new Dictionary<ExcelCellIdentifier, int>(new ExcelCellIdentifierComparer());
        public class ExcelCellIdentifier
        {
            private ExcelCellIdentifier(string ticker, string identifier)
            {
                Ticker = ticker;
                Identifier = identifier;
            }
            public string Ticker { get; set; }
            public string Identifier { get; set; }
        }
        private class ExcelCellIdentifierComparer : IEqualityComparer<ExcelCellIdentifier>
        {
            public bool Equals(ExcelCellIdentifier x, ExcelCellIdentifier y)
            {
                return x.Identifier == y.Identifier && x.Ticker == y.Ticker;
            }
            public int GetHashCode(ExcelCellIdentifier obj)
            {
                return obj.Identifier.GetHashCode() ^ obj.Ticker.GetHashCode();
            }
        }
