    private void grdDistProcessing_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
       Application.DoEvents(); //May not be required. Was necessary for me to access the data within the grid view's datasource.
    
       e.CellStyle.BackColor = Color.BurlyWood;
       e.CellStyle.ForeColor = Color.Black;
    
    }
