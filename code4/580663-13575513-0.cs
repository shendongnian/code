    DataTable dt=new DataTable(); 
    dt.clear(); 
    
    dt.Columns.Add("First Name");
    dt.Columns.Add("Last Name");
    dt.Columns.Add("RFID");
    dt.Columns.Add("Associate ID#");
    dt.Columns.Add("Diverts");
    dt.Columns.Add("MHE");
    dt.Columns.Add("Loading")
    
    DataRow yourDataRow = dt.NewDataRow();
    yourDataRow["First Name"] = //assign the value for FirstName here;
    yourDataRow["Last Name"] = //assing the value for LastName here; 
    dt.Rows.Add(yourDataRow);
