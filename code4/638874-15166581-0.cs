    DataRow[] drx = dt2.Select(string.Format("BASELINE_FILE = '{0}'" , filename));
    if (drx.Length == 1)
     {
        // do stuff with drx[0]
     }
     else
     {
        newRow = dt2.NewRow(); // newRow is a DataRow I declared up above
        newRow[3] = directory;
        newRow[4] = filename;
        newRow[5] = checksumList[j];
        newRow[6] = "Missing";
        dt2.Rows.Add(newRow); 
     }
