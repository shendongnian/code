    // assuming myTableId is a string
    
    try
    {
        int i = int.Parse(myTableId)
        e.Command.Parameters["@tableId"].Value = i;
    }
    catch
    {
        throw new ApplicationException("Table Id should be an integer");
    }
