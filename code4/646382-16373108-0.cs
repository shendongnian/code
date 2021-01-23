    public class Cache
    {
        protected SQLiteConnection Connection { get; set; }
        protected String TableName { get; set; }
        protected const Int32 PageSize = 512;
        protected CachePage PageCurrent { get; set; }
        protected IndexRange IndexRangeTable { get; set; }
        public Cache(SQLiteConnection connection, String tableName)
        {
            SQLiteConnection.ClearAllPools();
            this.Connection = connection;
            this.TableName = tableName;
            IndexRange indexRangeCurrent = new IndexRange(0, PageSize - 1);
            DataTable dataTableCurrent = this.GetDataTableFromTable(indexRangeCurrent);
            this.PageCurrent = new CachePage(indexRangeCurrent, dataTableCurrent);
        }
        public Object GetCellValue(Int32 rowIndex, Int32 columnIndex)
        {
            DataRow dataRowFound = this.PageCurrent.Data.Rows.Find(rowIndex);
            if (dataRowFound != null)
            {
                return dataRowFound[columnIndex];
            }
            else
            {
                this.ShiftPageToIndex(rowIndex);
                return GetCellValue(rowIndex, columnIndex);
            }
        }
        private void ShiftPageToIndex(Int32 index)
        {
            this.PageCurrent.Range.Start = index;
            this.PageCurrent.Range.Stop = index + PageSize;
            this.PageCurrent.Data = this.GetDataTableFromTable(this.PageCurrent.Range);
            this.PageCurrent.Range.Start = index;
            this.PageCurrent.Range.Stop = index + this.PageCurrent.Data.Rows.Count;
        }
        private IndexRange GetTableIndexRange()
        {
            String commandText = String.Format("SELECT MAX(RowId) FROM {0}", this.TableName);
            SQLiteCommand command = new SQLiteCommand(commandText, this.Connection);
            this.Connection.Open();
            command.CommandText = commandText;
            String maxRowIdString = command.ExecuteScalar().ToString();
            this.Connection.Close();
            Int32 maxRowId = Int32.Parse(maxRowIdString);
            return new IndexRange(0, maxRowId);
        }
        private DataTable GetDataTableFromTable(IndexRange indexRange)
        {
            if (this.Connection != null)
            {
                String commandText = String.Format("SELECT * FROM {0} WHERE RowId BETWEEN {1} AND {2}", this.TableName, indexRange.Start, indexRange.Stop);
                SQLiteCommand command = new SQLiteCommand(commandText, this.Connection);
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                DataTable dataTable = new DataTable(this.TableName, this.TableName);
                dataAdapter.Fill(dataTable);
                dataTable.Columns.Add("RowId", typeof(Int64));
                for (Int32 i = 0; i < dataTable.Rows.Count; i++)
                {
                    dataTable.Rows[i]["RowId"] = i + indexRange.Start;
                }
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["Rowid"] };
                return dataTable;
            }
            else
            {
                return null;
            }
        }
    }
    public class CachePage
    {
        public CachePage(IndexRange range, DataTable data)
        {
            this.Range = range;
            this.Data = data;
        }
        public IndexRange Range {get; set;}
        public DataTable Data {get; set;}
    } 
    public class IndexRange
    {
        public Int32 Start {get; set;}
        public Int32 Stop { get; set; }
        public IndexRange(Int32 start, Int32 stop)
        {
            this.Start = start;
            this.Stop = stop;
        }
    }
