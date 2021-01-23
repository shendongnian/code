    You have to passed Sheet object, but in below code SQL statement fire and get all records in DataSet object.   
    string sql = "SELECT * FROM [" + selectedWorksheetName + "]";
    var adapter = new OleDbDataAdapter(sql, excelObject.Connection);
    adapter.Fill(activityDataSet, "Results");
            
    if (activityDataSet.Tables[0] != null)
    {
         //here you will check which data get based on your columns
    }
