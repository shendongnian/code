    Since I'm getting the full precision while reading the excel type as general to the C# datatable, I created a datatable clone by chaning the column type alone as string, so that i'll get the values all string type as well as with full precision, then i'm passing the datatable to SQL 2008 table without losing the precision,Now its working fine.
    Code:
    dt= ds.Tables[0].Clone();
    for (ICol = 0; ICol < ds.Tables[0].Columns.Count; ICol++)
        dt.Columns[ICol].DataType = typeof(string);
        foreach (DataRow row in ds.Tables[0].Rows) 
        {
            dt.ImportRow(row); 
    }
