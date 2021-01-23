    string dbfile = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "\\TelemarketingDatabase.sdf";
    SqlCeConnection connection = new SqlCeConnection("datasource=" + dbfile);
    
    TelemarketingDatabaseDataSet ds = new TelemarketingDatabaseDataSet();   
    SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from Calls", connection);
    adapter.Fill(ds,"Calls");
    adapter.UpdateCommand = new SqlCommandBuilder(adapter).GetUpdateCommand(); //added
    
    DataTable tbl = ds.Tables["Calls"];
    var row = tbl.NewRow();
    row[0] = caller;
    row[1] = called;
    row[2] = duration;
    row[3] = Convert.ToDateTime(time);
    tbl.Rows.Add(row);
    adapter.Update(ds,"Calls");
