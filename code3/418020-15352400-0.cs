    foreach(Info info in infoList)
    {
       DataRow row = dataTable.NewRow(); 
       row["item1"] = info.Item1; //where Item1 could be a string 
       row["Item2"] = info.Item2; //where Item2 could be an int
       row["item3"] = info.Item3; //Where Item3 could be a DateTime
       row["Item4"] = info.Item4; //Where Item4 could be a Decimal
       dataTable.Rows.Add(row); //<-- You need to add this line to actually save the value to the Data Table
    }
