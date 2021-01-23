        // Invented by yccheok :)
        public IEnumerable<IEnumerable<object>> ExecuteScalarEx()
        {
            if (_conn.Trace)
            {
                Debug.WriteLine("Executing Query: " + this);
            }
            List<List<object>> result = new List<List<object>>();
            var stmt = Prepare();
            while (SQLite3.Step(stmt) == SQLite3.Result.Row)
            {
                int columnCount = SQLite3.ColumnCount(stmt);
                List<object> row = new List<object>();
                for (int i = 0; i < columnCount; i++)
                {
                    var colType = SQLite3.ColumnType(stmt, i);
                    object val = ReadColEx (stmt, i, colType);
                    row.Add(val);
                }
                result.Add(row);
            }
            return result;
        }
		
        // Invented by yccheok :)
        object ReadColEx (Sqlite3Statement stmt, int index, SQLite3.ColType type)
        {
            if (type == SQLite3.ColType.Null) {
                return null;
            } else {
                if (type == SQLite3.ColType.Text) {
                    return SQLite3.ColumnString (stmt, index);
                }
                else if (type == SQLite3.ColType.Integer)
                {
                    return (int)SQLite3.ColumnInt (stmt, index);
                }
                else if (type == SQLite3.ColType.Float)
                {
                    return SQLite3.ColumnDouble(stmt, index);
                }
                else if (type == SQLite3.ColType.Blob)
                {
                    return SQLite3.ColumnBlob(stmt, index);
                }
                else
                {
                    throw new NotSupportedException("Don't know how to read " + type);
                }
            }
		}
