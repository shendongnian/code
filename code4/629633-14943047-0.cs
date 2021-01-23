    private void MyColumnChanging(object sender, DataColumnChangeEventArgs e)
    {
       // just to enforce column name representation, forcing to lower
       string colName = e.Column.ColumnName.ToLower();
       // e.Row has the row that had the change for you to work with, validate, etc...
       switch (colName)
       {
          case "yourcolumnfieldx":
             doSomething;
             break;
    
          case "anotherfield":
             doSomethingElse;
             break;
       }
    }
