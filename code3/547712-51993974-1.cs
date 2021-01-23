        private static Dictionary<string, object> Read(IDataRecord reader)
        {
            var row = new Dictionary<string, object>();
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var val = reader[i];
                row[reader.GetName(i)] = val == DBNull.Value ? null : val;
            }
            return row;
        }
