    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lbl = e.Row.FindControl("lbl") as Label;
        if (lbl != null) {
            var encrypted = DataBinder.Eval(e.Row.DataItem, "EncryptedColumn");
            string decrypted = Decrypt(encrypted);
            lbl.Text = decrypted;
        }
    }
