    try
    {
        var row = gvTransactions.CurrentRow;
        int ID= int.parse(row.Cells[0].Value.ToString());
        string abc=row.Cells[0].Value.ToString();
    }
    catch(exception ex)
    {
    }
