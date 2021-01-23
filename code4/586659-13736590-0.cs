    public struct DbTable
    {
        public DbTable(string tableName, int tableId)
        {
            this.TableName = tableName;
            this.TableID = tableId;
        }
        public string TableName { get; private set; }
        public int TableID { get; private set; }
    }
