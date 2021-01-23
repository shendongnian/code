    static DataTable table = null;
    static DataTable GetTable()
    {
        if(table == null){
            table = new DataTable();
            table.Columns.Add("gamekey", typeof(string));
            table.Columns.Add("countdown", typeof(int));
        }
        return table;
    }
