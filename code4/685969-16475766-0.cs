    private void RefreshCombo()
    {
     SqlCommand cmd = new SqlCommand("SELECT DISTINCT(TXT_TARGET_NUMBER) FROM TBL_CDR_ANALYZER", sqlCon);
    cboTargetNo.Properties.Items.Clear();
    cboTargetNo.Properties.Items.Add("Choose Target Number");
    sqlCon.Open();
    SqlDataReader dr = cmd.ExecuteReader();
    while (dr.Read())
    {
        cboTargetNo.Properties.Items.Add(dr["TXT_TARGET_NUMBER"]);
    }
    sqlCon.Close();
    cboTargetNo.SelectedIndex = 0;
    }
