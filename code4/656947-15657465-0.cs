    protected void rgGrid_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("Edit"))
        {
            int id = int.Parse(e.Item.Cells[0].Text);
            Response.Redirect("~/Administrator/UserEditPanel.aspx?userId=" + id);
        }
        else if (e.CommandName.Equals("Delete"))
        {
            int id = int.Parse(e.Item.Cells[0].Text);
            HtUser.DeleteUserById(id);
        }
    }
