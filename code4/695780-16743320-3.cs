        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        TextBox Textbox1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox1 ");
        Label Label2 = new Label();
        Label2.Text = Textbox1.Text.Replace("_", ""); //Replace Gridview for the text box
        GridView1.DataBind();
    }
