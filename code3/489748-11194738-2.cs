    protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Page1Value"] = ListBox3.SelectedItem.Text;
           //Response.Redirect("~/Page2.aspx");
        }
