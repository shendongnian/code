    var grouped = from myRow in myDataTable.AsEnumerable()
                  group myRow by myRow.Field<int>("TIMESTAMP");
    foreach (var timestamp in grouped)
    {
        string[] myRow = new string[5];
        myRow[0] = timestamp.Key.ToString();
        
        int i = 1;
        foreach (var value in timestamp)
        {
          myRow[i] = value.Field<double>("VALUE").ToString();
          i++;
          if (i > 4)
              break;
        }
        mySortedTable.Rows.Add(myRow);
    }
