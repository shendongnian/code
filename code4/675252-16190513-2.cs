    private void Check_Val()
    {
        DataTable myTable = new DataTable();
        myTable = SQL_ValidateCheck(mygrid.CurrentSelection.Cells[0].Value.ToString());
        //Iterate the table for the result, maybe use an if(mytable == null) or something
    }
