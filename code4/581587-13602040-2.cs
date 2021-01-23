    protected void cmdTest_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gvTest.Rows.Count; i++)
        {
            int qty = Convert.ToInt32(((TextBox)gvTest.Rows[i].FindControl("txtQty")).Text);
            // code here
        }
    }
