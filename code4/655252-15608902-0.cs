  using ( SqlCommand cmdMeasureHist = new SqlCommand("GetMeasureDetailHistory", conn))
        {
        cmdMeasureHist.CommandType = CommandType.StoredProcedure;
        SqlParameter pclinic = cmdMeasureHist.Parameters.Add("@ClinicID", SqlDbType.Int);
        pclinic.Value = ClinicID;
        SqlParameter pCMSMID = cmdMeasureHist.Parameters.Add("@CMMeasureID", SqlDbType.Int);
        pCMSMID.Value = Convert.ToInt32(ddMeasures.SelectedValue);
        
        SqlDataAdapter da = new SqlDataAdapter(cmdMeasureHist);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gvHistory.DataSource = dt;
        gvHistory.DataBind();
