    ColumnElementType[] columns =  new ColumnElementType[3];
    int index = 0;
    columns.AddColumn(Constants.EmailColumnName, email, index++);
    columns.AddColumn(Constants.FirstNameColumnName, firstName, index++);
    columns.AddColumn(Constants.LastNameColumnName, lastName, index++);
    //...
    public static void AddColumn(..., int index)
    {
      // Add a new column to the column list
      columnListToAddTo[index] = new ColumnElementType { ... };
    }
