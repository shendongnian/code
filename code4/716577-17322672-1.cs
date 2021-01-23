    protected void btnReceive_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
                gvrow.Visible = false;
        }
    }
