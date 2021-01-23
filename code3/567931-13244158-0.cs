    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {
        for (int count = 0; count < RadGrid1.PageSize; count++)
        {
            RadGrid1.EditIndexes.Add(count);
        }
        
        RadGrid1.Rebind();
    }
