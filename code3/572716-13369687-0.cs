    protected void Page_Load(object sender, EventArgs e)
    {
        // Fetch the text from your label. (I'm assuming that you have only one label with the text "3244|Yellow Ink| Test Link".
        string text = Label1.Text;
        
        // Find the first row or return null if not found.
        var resultRow = GridView1.Rows.Cast<GridViewRow>().FirstOrDefault(row =>
        {
            // Get the id (that I'm guessing is the first (0-index) column/cell)
            var id = row.Cells[0].Text;
    
            // Return true/false if the label text starts with the same id.
            return text.StartsWith(id);
        });
    
        if (resultRow != null)
        {
            var index = resultRow.RowIndex;
        }
    }
    
