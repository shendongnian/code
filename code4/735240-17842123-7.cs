    protected void btnDelete_OnClick(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer
        string desiredText = row.Cells[3].Text;
        using (objConexao = new SqlConnection(strStringConexao))
        {
            // ...
            myParam2.Value = desiredText;
            // ...
        }        
    }
