    var list = DTTable2.Rows.ToList();//create new list of rows
    foreach (DataRow DR in list)
    {
        //if bla bla bla
        DTTable2.Rows.Remove(DR);
    }
