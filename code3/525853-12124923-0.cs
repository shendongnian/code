    void SortGrid(Object sender, DataGridSortCommandEventArgs e) 
    {
    }
    	
    void Btn_Click(Object sender,EventArgs e)
    {
            SortGrid(YourDataGrid, new DataGridSortCommandEventArgs{SortExpression = value, CommandSource = value});
        //You pass yours values
    }
 
