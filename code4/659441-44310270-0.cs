        public void StoreData(DbContext dbContext, Dictionary<string, string> columnInfo, List<Dictionary<string, object>> multiInsertObj, string tableName)
        {
            _ctx = dbContext;
            _columnInfo = columnInfo;
            var sb = new StringBuilder();
            var i = 0;
            sb.Append(BuildSqlCommand(tableName, columnInfo, multiInsertObj.Count));
            ExecuteSqlCommand(sb, GetParamsObject(columnInfo, multiInsertObj));
        }
        private static StringBuilder BuildSqlCommand(string tableName, Dictionary<string, string> variableInfo, int variableCount)
        {
            //Build sql command
            var sb = new StringBuilder();
            sb.Append("INSERT INTO dbo." + tableName + "(");
            foreach (var variable in variableInfo)
            {
                sb.Append(variable.Key);
                sb.Append(", ");
            }
            sb.Append("SystemNumber, ");
            sb.Remove(sb.Length - 2, 2).Append(") VALUES ");
            for (var i = 0; i < variableCount; i++)
            {
                sb.Append("(");
                foreach (var name in variableInfo.Keys)
                {
                    sb.Append("@" + name + "_" + i + ",");
                }
                sb.Append("@SystemNumber" + "_" + i + ",");
                sb.Remove(sb.Length - 1, 1).Append("),");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb;
        }
        private static object[] GetParamsObject(Dictionary<string, string> columnInfo, List<Dictionary<string, object>> multiInsertObj)
        {
            var variableCount = multiInsertObj.Count;
            var rowCount = multiInsertObj[0].Keys.Count;
            var objectLength = (rowCount + 1) * variableCount;
            var variableDataTypes = columnInfo.Values.ToList();
            var paramObj = new object[objectLength];
            var j = 0;
            var i = 0;
            foreach (var row in multiInsertObj)
            {
                var k = 0;
                foreach (var data in row)
                {
                    var sb = new StringBuilder();
                    sb.Append("@");
                    sb.Append(data.Key);
                    sb.Append("_" + i);
                    paramObj[j] = new SqlParameter(sb.ToString(), SetSqlDataType(variableDataTypes[k])) { Direction = Input, Value = data.Value };
                    j++;
                    k++;
                }
                paramObj[j] = new SqlParameter(("@SystemNumber" + "_" + i), SetSqlDataType("int")) { Direction = Input, Value = _systemNumber };
                i++;
                j++;
            }
            return paramObj;
        }
        private static void ExecuteSqlCommand(StringBuilder sb, params object[] sqlParameters)
        {
            using (_ctx)
            {
                _ctx.Database.Connection.Open();
                using (var cmd = _ctx.Database.Connection.CreateCommand())
                {
                    cmd.CommandText = sb.ToString();
                    foreach (var param in sqlParameters)
                        cmd.Parameters.Add(param);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }
