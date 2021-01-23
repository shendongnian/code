    protected void btnGetNPMEmailAddresses_Click(object sender, EventArgs e)
    {
        // TODO:: Populate ObjectDataSource_Designee
        DataSet dataSet = GetDS(ObjectDataSource_Designee);
        string emails = string.Empty;
        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        {
            emails = emails + dataSet.Tables[0].Rows[0]["EmailAddresses"].ToString() + Environment.NewLine;
        }
        txbResults.Text = emails;
    }
    private DataSet GetDS(ObjectDataSource ods)
    {
        var ds = new DataSet();
        var dv = (DataView)ods.Select();
        if (dv != null && dv.Count > 0)
        {
            var dt = dv.ToTable();
            ds.Tables.Add(dt);
        }
        return ds;
    }
