    DataTable table = new DataTable();
    DataColumn dc = table.Columns.Add("day",typeof(string));
    
    table.Rows.Add(days[0]);
    table.Rows.Add(days[2]);
    
    //query
    foreach(string day in days) {
        foreach(DataRow row in table.Rows) {
            if(row[dc] == day) {
                Console.WriteLine("Row {0} contains {1}",row,day);
            }
        }
        Console.WriteLine();
    }
