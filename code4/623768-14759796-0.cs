        string[] TABLE_COLUMNS = new string[] { "PilotID", "Start_date", "End_date", "Hours", };
        static void Main()
        {
            var i_need_new_table = HardCodedDataTable();
            var i_need_one_more_new_table = HardCodedDataTable(TABLE_COLUMNS);
        }
        private static DataTable HardCodedDataTable() // default hard-coded table
        {
            DataTable myTable = new DataTable();
            myTable.Columns.Add("PilotID");
            myTable.Columns.Add("Start_date");
            myTable.Columns.Add("End_date");
            myTable.Columns.Add("Hours");
            return myTable;
        }
        private static DataTable HardCodedDataTable(string[] columns) // table with predefined columns in array
        {
            DataTable myTable = new DataTable();
            Array.ForEach(columns, s => myTable.Columns.Add(s));
            return myTable;
        }
