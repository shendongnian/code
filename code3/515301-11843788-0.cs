    DataTable dt = new DataTable();
    dt.Columns.Add("UniqueColumn1");
    dt.Columns.Add("UniqueColumn2");
    dt.Columns.Add("UniqueColumn3");
    dt.Columns.Add("NormalColumn");
    
    string 
           value1 = string.Empty, 
           value2 = string.Empty, 
           value3 = string.Empty, 
           value4 = string.Empty;
    //Logic to take values in string values variables goes here
    DataRow[] founded = dt.Select("UniqueColumn1 = '"+ value1+
                                  "' and UniqueColumn2 = '"+value2+
                                  "' and UniqueColumn3 = '"+value3+"'");
    if (founded.Length > 0)
          // Message to say values already exist.
    else
          // Add a new row to your dt.
