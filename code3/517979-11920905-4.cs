    DataRow row = cityTable.NewRow();
    row[0] = 100;
    row["City Name"] = Anaheim;
    row["Column 7"] = ...
    ...
    row["Column 26"] = checksum;
    
    workTable.Rows.Add( row );
    
