        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
    
        TextBox Textbox1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox1 ");
        Label Label2 = new Label();
        Label2.Text = GridView1.Text.Replace("_", "");
        GridView1.DataBind();
    }
