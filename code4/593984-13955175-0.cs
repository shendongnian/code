    protected void PollBindData()
    {
        SqlConnection connOption = new SqlConnection(connStr);
        connOption.Open();
        // POTENTIAL SECURITY RISK - MAKE SURE YOU PARAMETRIZE THE QUERY!!
        SqlDataAdapter da = new SqlDataAdapter("SELECT POptionID, OptionText, Votes FROM [PollOptions] Where PollID = '" + PID + "'", connOption);
        DataTable dsSel = new DataTable();
        da.Fill(dsSel);
        lvPollOptions.DataSource = dsSel;
        lvPollOptions.DataBind();
        connOption.Close();
        // Update panel
        UpdateOptions.Update();
    }
