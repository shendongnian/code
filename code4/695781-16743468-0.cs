    protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        TextBox Textbox1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox1");
        Textbox1.Text = Regex.Replace(Textbox1.Text, "_", "");
    }
