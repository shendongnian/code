    protected void Button1_Click(object sender, EventArgs e)
    {
        string CatID = string.Empty;
        foreach (ListItem li in lstCatID.Items)
        {
            if (li.Selected )
            {
               // TODO: Whatever you are doing with a selected item.
            }
        }
        Response.Write(CatID);
    }
