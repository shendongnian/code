    //code to wire up the handler
    custTable.ColumnChanged += new DataColumnChangeEventHandler(Column_Changed);
    //code for the event
    private static void Column_Changed(object sender, DataColumnChangeEventArgs e )
    {
        Console.WriteLine("Column_Changed Event: name={0}; Column={1}; original name={2}", 
            e.Row["name"], e.Column.ColumnName, e.Row["name", DataRowVersion.Original]);
    }
