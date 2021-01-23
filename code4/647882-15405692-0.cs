        else if (e.CommandName == "Delete")
        {     
            int index = Convert.ToInt32(e.CommandArgument);
            GridView1.DeleteRow(index);
            ((DataTable)ViewState["DataTable"]).Rows[index].Delete();
            ((DataTable)ViewState["DataTable"]).AcceptChanges();
            GridView1.DataSource = (DataTable)ViewState["Data"];
            GridView1.DataBind();
        }
