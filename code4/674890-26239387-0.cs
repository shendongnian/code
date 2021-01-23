        private IEnumerable<string> GetColumnNames(string conStr, string tableName)
        {
            var result = new List<string>();
            using (var sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                var sqlCmd = sqlCon.CreateCommand();
                sqlCmd.CommandText = "select * from " + tableName + " where 1=0";  // No data wanted, only schema
                sqlCmd.CommandType = CommandType.Text;
                var sqlDR = sqlCmd.ExecuteReader();
                var dataTable = sqlDR.GetSchemaTable();
                foreach (DataRow row in dataTable.Rows) result.Add(row.Field<string>("ColumnName"));
            }
            return result;
        }
