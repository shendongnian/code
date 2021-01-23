    public class LogFileEntry : IEqualityComparer<LogFileEntry>
    {
        private readonly string[] _rows;
        public LogFileEntry(string[] rows)
        {
            _rows = rows;
        }
        #region Implementation of IEqualityComparer<in LogFileEntry>
        public bool Equals(LogFileEntry x, LogFileEntry y)
        {
            return 
                x._rows[0].Equals(y._rows[0]) &&
                x._rows[1].Equals(y._rows[1]) &&
                x._rows[2].Equals(y._rows[2]) &&
                x._rows[3].Equals(y._rows[3]);
        }
        public int GetHashCode(LogFileEntry obj)
        {
            return obj._rows.Sum(o => o.GetHashCode());
        }
        #endregion
    }
