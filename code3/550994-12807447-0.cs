    // Get your data from SQL Server into a DataTable
    // This will store the generated output. If your input data is very large
    // you can use a TextWriter and write directly to a text file on disk.
    StringBuilder sbOutput = new StringBuilder ();
    foreach ( column in dataTable.Columns )
    {
        sbOutput.Append ( column.Name ).Append ( "\t" );
    }
    sbOutput.AppendLine ();
    
    foreach ( row in dataTable.Rows )
    {
        // Internally this loops through all cells in the row and append
        // all values to sbOutput, separated by tabs (\t). It also appends
        // a newline at the end of the line.
        GenerateRow ( sbOutput, row );
    }
    File.WriteAllText ( "c:\...", sbOutput.ToString () );
    
