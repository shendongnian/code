    void MainDataGrid_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
    {
       TextBox tb = e.Column.GetCellContent(e.Row) as TextBox;
       tb.TextChanged+=new TextChangedEventHandler(tb_TextChanged); 
    }
    void tb_TextChanged(object sender, TextChangedEventArgs e)
    {
       //here, something changed the cell's text. you can do what is neccesary
    }
