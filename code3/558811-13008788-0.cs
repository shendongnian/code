    for (int intCount = 0; intCount < dsDetails.Tables[0].Rows.Count; intCount++)
    {
        if (lblCountryName.Text.Equals(dsDetails.Tables[0].Rows[intCount][0].ToString()))
        {
            dsDetails.Tables[0].Rows[intCount][3] = txtPopulation.Text;
        }
    }  
    dsDetails.Tables[0].AcceptChanges();
