    public class DataRetrieverLog : IDataPageRetriever
    {
        private string tableName;
        private string sortColumn;
        private SqlCommand command;
        private DataTable table;
        private SqlDataAdapter adapter;
        public DataRetrieverLog(string connectionString, string tableName, string sortColumn)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            command = connection.CreateCommand();
            this.tableName = tableName;
            this.sortColumn = sortColumn;
        }
        private int rowCountValue = -1;
        public int RowCount
        {
            get
            {
                // Return the existing value if it has already been determined. 
                if (rowCountValue != -1)
                {
                    return rowCountValue;
                }
                // Retrieve the row count from the database.
                command.CommandText = "SELECT COUNT(*) FROM " + tableName;
                rowCountValue = (int)command.ExecuteScalar();
                return rowCountValue;
            }
        }
        private DataColumnCollection columnsValue;
        public DataColumnCollection Columns
        {
            get
            {
                // Return the existing value if it has already been determined. 
                if (columnsValue != null)
                {
                    return columnsValue;
                }
                // Retrieve the column information from the database.
                command.CommandText = "SELECT * FROM " + tableName;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.FillSchema(table, SchemaType.Source);
                columnsValue = table.Columns;
                return columnsValue;
            }
        }
        private string commaSeparatedListOfColumnNamesValue = null;
        private string CommaSeparatedListOfColumnNames
        {
            get
            {
                // Return the existing value if it has already been determined. 
                if (commaSeparatedListOfColumnNamesValue != null)
                {
                    return commaSeparatedListOfColumnNamesValue;
                }
                // Store a list of column names for use in the 
                // SupplyPageOfData method.
                System.Text.StringBuilder commaSeparatedColumnNames =
                    new System.Text.StringBuilder();
                bool firstColumn = true;
                foreach (DataColumn column in Columns)
                {
                    if (!firstColumn)
                    {
                        commaSeparatedColumnNames.Append("], [");
                    }
                    else
                    {
                        commaSeparatedColumnNames.Append("[");
                    }
                    commaSeparatedColumnNames.Append(column.ColumnName);
                    firstColumn = false;
                }
                commaSeparatedColumnNames.Append("]");
                commaSeparatedListOfColumnNamesValue =
                    commaSeparatedColumnNames.ToString();
                return commaSeparatedListOfColumnNamesValue;
            }
        }
        // Declare variables to be reused by the SupplyPageOfData method. 
        private string columnToSortBy;
        
        public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            
            // Store the name of the ID column. This column must contain unique  
            // values so the SQL below will work properly. 
            if (columnToSortBy == null)
            {
                columnToSortBy = this.Columns[0].ColumnName;
            }
            if (!this.Columns[columnToSortBy].Unique)
            {
                throw new InvalidOperationException(String.Format(
                    "Column {0} must contain unique values.", columnToSortBy));
            }
            
            // Retrieve the specified number of rows from the database, starting 
            // with the row specified by the lowerPageBoundary parameter.
            String text = "Select Top " + rowsPerPage + " " +
                CommaSeparatedListOfColumnNames + " From " + tableName +
                " WHERE " + columnToSortBy + " NOT IN (SELECT TOP " +
                lowerPageBoundary + " " + columnToSortBy + " From " +
                tableName + " Order By " + sortColumn +
                ") Order By " + sortColumn;
            command.CommandText = text;
            adapter = new SqlDataAdapter(text, GUI.dictSettings["connectionString"]);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);
            return table;
        }
        public DataTable getDataTable()
        {
            return table;
        }
        public SqlDataAdapter getAdapter()
        {
            return adapter;
        }
    }
