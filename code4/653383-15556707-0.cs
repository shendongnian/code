    DataTable table = new DataTable();
    table.Columns.Add("Question", typeof(string));
    table.Columns.Add("Fred", typeof(int));
    table.Columns.Add("Bill", typeof(int));
    table.Columns.Add("Rhona", typeof(int));
    table.Columns.Add("Peter", typeof(int));
    table.Rows.Add("2D", 54, 75, 23, 88);
    table.Rows.Add("3D", 92, 31, 77, 87);
    table.Rows.Add("4D", 63, 56, 45, 35);
    table.Rows.Add("5D", 98, 23, 65, 67);
   
    //convert datatable to a IEnumerable form 
    var IEtable = (table as System.ComponentModel.IListSource).GetList();
 
    Chart.DataBindTable(IEtable, "Question");
