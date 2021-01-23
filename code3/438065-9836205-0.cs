    public UserData(DataRow row)
    {
         // At this point, the row may be reliable enough for you to
         // attempt to reference by column names. If not, fall back to indexes
     
        this.Name = Convert.ToString(row.Table.Columns.Contains("Name") ? row["Name"] : row[0]);
        this.Age = Convert.ToInt32(row.Table.Columns.Contains("Age") ? row["Age"] : row[1]);
        this.City = Convert.ToString(row.Table.Columns.Contains("City") ? row["City"] : row[2] );
    }
