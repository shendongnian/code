    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                TextBox txtName = GridView1.FooterRow.FindControl("txtSName") as TextBox;
                string aa = txtName.Text;
            }
