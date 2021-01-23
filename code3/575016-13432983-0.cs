    public class SqlIndexInfo
    {
        public string IndexName { get; set; }
        public string TableName { get; set; }
        public string[] Fields { get; set; }
        public bool IsAscending { get; set; }
        public bool IsComposite
        {
            get { return Fields.Length > 1; }
        }
    }
    public static class Extensions
    {
        public static SqlIndexInfo ParseToIndexInfo(this string sql)
        {
            sql = sql.Trim();
            var info = new SqlIndexInfo();
            var i = sql.IndexOf("CREATE INDEX", 0, StringComparison.InvariantCultureIgnoreCase);
            if (i < 0) throw new ArgumentException("String is not valid CREATE INDEX SQL");
            var indexNameStart = i + "CREATE INDEX".Length + 1;
            i = sql.IndexOf(" ON ", 0, StringComparison.InvariantCultureIgnoreCase);
            if (i < 0) throw new ArgumentException("String is not valid CREATE INDEX SQL");
            var indexNameEnd = i;
            var tableNameStart = i + " ON ".Length;
            i = sql.IndexOf("(", 0, StringComparison.InvariantCultureIgnoreCase);
            if (i < 0) throw new ArgumentException("String is not valid CREATE INDEX SQL");
            var tableNameEnd = i;
            var fieldNamesStart = i + 1;
            i = sql.IndexOf(")", 0, StringComparison.InvariantCultureIgnoreCase);
            if (i < 0) throw new ArgumentException("String is not valid CREATE INDEX SQL");
            var fieldNamesEnd = i;
            var directionStart = i + 1;
            // TODO: strip brackets and/or single quotes?
            info.IndexName = sql.Substring(indexNameStart, indexNameEnd - indexNameStart).Trim();
            info.TableName = sql.Substring(tableNameStart, tableNameEnd - tableNameStart).Trim();
            info.Fields = (from f in sql.Substring(fieldNamesStart, fieldNamesEnd - fieldNamesStart).Split(',')
                          where !string.IsNullOrEmpty(f)
                          select f.Trim()).ToArray();
            if (directionStart >= sql.Length)
            {
                info.IsAscending = true;
            }
            else
            {
                info.IsAscending = sql.IndexOf("ASC", directionStart, StringComparison.InvariantCultureIgnoreCase) >= 0;
            }
            return info;
        }
    }
