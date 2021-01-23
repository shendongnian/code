    public void InitPathsTable()
    {
           int rowindex;
           DataGridViewRow row;
           
           foreach (var line in _PathRows)
           {
                   rowindex = TabelleBib.Rows.Add(); //retrieve row index of newly added row
                   row = TabelleBib.Rows[rowindex];  //reference to new row
                   
                   row.Cells[3].Value = line; //set value of 4th column to line. WARNING: TabelleBib has to have 4 columns added either from code or designer othwerwise here you will get exception
           }
    }
