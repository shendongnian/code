    for (z=0; z < dt.Columns.Count; z++)
    {
      // check to see if the column name is the required name passed in.
      if (dt.Columns[z].ColumnName == fieldName)
      {
        // If the column was found then retrieve it 
        //dc = dt.Columns[z];
        // and stop looking the rest of the columns
        requiredColumn = z;
        break;
     }
