    for(int i=0;i<MaxRows;i++)
            {
    
            DataRow dRow = dsl.Tables["Employee"].Rows[inc];
            displayID = dRow.ItemArray.GetValue(0).ToString();
            displayFname = dRow.ItemArray.GetValue(1).ToString();
            displayLname = dRow.ItemArray.GetValue(2).ToString();
            displayAge = dRow.ItemArray.GetValue(3).ToString();
            displayJob = dRow.ItemArray.GetValue(4).ToString();
            viewAll = viewAll + displayID + " " + displayFname + " " + displayLname + " " + displayAge + " " + displayJob + " ";
            }
