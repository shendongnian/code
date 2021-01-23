    protected void btnDelete_OnClick(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string desiredText = btn.Text;
        using (objConexao = new SqlConnection(strStringConexao))
        {
            // ...
            myParam2.Value = desiredText;
            // ...
        }        
    }
