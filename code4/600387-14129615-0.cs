    private int colTotal = 0; // class level
    public Myclass()
    { 
        // Add a ColumnChanged event handler for the table.
        MyDataTable.ColumnChanged += new DataColumnChangeEventHandler(Column_Changed);
        // wire up more event handlers here..
    }
    private static void Column_Changed(object sender, DataColumnChangeEventArgs e )
    {
       calculateTotal();
    }
    
    // calculate total of specified column
    void calculateTotal()
    {
       colTotal = myDataSet.Tables["myTable"].Compute("SUM(myColumnName)", String.Empty);
    } 
