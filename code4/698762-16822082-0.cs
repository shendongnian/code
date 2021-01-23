    public class SqlDatabaseAdapter
    {
        private readonly ServerConnection _serverConnection;
        public SqlDatabaseAdapter(string connectionString)
        {
            _serverConnection = new ServerConnection(new SqlConnection(connectionString));
        }
        public DataSet GetTables(string databaseName = "master")
        {
            var server = new Server(_serverConnection);
            var database = server.Databases.Cast<Database>().FirstOrDefault(d => d.Name == databaseName);
            var dataSet = new DataSet(databaseName);
            if (database == null) return dataSet;
            foreach (var table in database.Tables.Cast<Table>())
            {
                var dataTable = new DataTable(table.Name);
                FillColumns(table, dataTable);
                dataSet.Tables.Add(dataTable);
            }
            return dataSet;
        }
        public DataTable GetTable(string tableName, string databaseName = "master")
        {
            var server = new Server(_serverConnection);
            var database = server.Databases.Cast<Database>().FirstOrDefault(d => d.Name == databaseName);
            var dataTable = new DataTable(tableName);
            if (database == null) return dataTable;
            database.Refresh();
            var table = database.Tables.Cast<Table>().FirstOrDefault(f => f.Name == tableName);
            if (table == null) return dataTable;
            FillColumns(table, dataTable);
            return dataTable;
        }
        private static void FillColumns(Table table, DataTable dataTable)
        {
            foreach (Column column in table.Columns)
            {
                var type = ConvertToClrType(column.DataType.SqlDataType, column.Nullable);
                var dataColumn = new DataColumn(column.Name, type);
                dataTable.Columns.Add(dataColumn);
            }
        }
        private static Type ConvertToClrType(SqlDataType sqlDataType, bool nullable)
        {
            switch (sqlDataType)
            {
                case SqlDataType.BigInt:
                    return nullable ? typeof (long?) : typeof (long);
                case SqlDataType.Binary:
                case SqlDataType.Image:
                case SqlDataType.Timestamp:
                case SqlDataType.VarBinary:
                    return typeof (byte[]);
                case SqlDataType.Bit:
                    return nullable ? typeof (bool?) : typeof (bool);
                case SqlDataType.Char:
                case SqlDataType.NChar:
                case SqlDataType.NText:
                case SqlDataType.NVarChar:
                case SqlDataType.Text:
                case SqlDataType.VarChar:
                case SqlDataType.Xml:
                    return typeof (string);
                case SqlDataType.DateTime:
                case SqlDataType.SmallDateTime:
                case SqlDataType.Date:
                case SqlDataType.Time:
                case SqlDataType.DateTime2:
                    return nullable ? typeof (DateTime?) : typeof (DateTime);
                case SqlDataType.Decimal:
                case SqlDataType.Money:
                case SqlDataType.SmallMoney:
                case SqlDataType.Numeric:
                    return nullable ? typeof (decimal?) : typeof (decimal);
                case SqlDataType.Float:
                    return nullable ? typeof (double?) : typeof (double);
                case SqlDataType.Int:
                    return nullable ? typeof (int?) : typeof (int);
                case SqlDataType.Real:
                    return nullable ? typeof (float?) : typeof (float);
                case SqlDataType.UniqueIdentifier:
                    return nullable ? typeof (Guid?) : typeof (Guid);
                case SqlDataType.SmallInt:
                    return nullable ? typeof (short?) : typeof (short);
                case SqlDataType.TinyInt:
                    return typeof (byte?);
                case SqlDataType.Variant:
                    return typeof (object);
                case SqlDataType.DateTimeOffset:
                    return nullable ? typeof (DateTimeOffset?) : typeof (DateTimeOffset);
                default:
                    throw new ArgumentOutOfRangeException("sqlDataType");
            }
        }
    }
