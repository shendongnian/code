    private void cb_SelectedValueChanged(object sender, EventArgs e)
    {
        if (!(sender is ComboBox)) return;
        ComboBox cb = sender as ComboBox;
        if (DataUtils.ToInt(cb.Tag, 0) == 0) return;
        if (cbSmk.SelectedValue == null ) return;
        /* Continue working;  */
    }
    public static void ComboboxFill(ComboBox cb, string keyfld, string displayfld, string sql)
    {          
        try
        {
            cb.Tag = 0;
            cb.DataSource = null;
            cb.Items.Clear();
                
            DataSet ds = DataMgr.GetDsBySql(sql);
            if (!DataUtils.HasDtWithRecNoErr(ds))
            {                    
                cb.Text = "No data";
            }
            else
            {
                cb.DataSource = ds.Tables[0];
                cb.DisplayMember = displayfld;
                cb.ValueMember = keyfld;
            }
            cb.Tag = cb.Items.Count;
        }
        catch (Exception ex)
        {
            Int32 len = ex.Message.Length > 200 ? 200 : ex.Message.Length;
            cb.Text = ex.Message.Substring(0, len);
        }                
    }
    CmpHelper.ComboboxFill(cbUser, "USER_ID", "USER_NAME", "SELECT * FROM SP_USER WHERE 1=1 ORDER by 1",-1);
