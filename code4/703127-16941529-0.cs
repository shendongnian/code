    SqlParameter param = new SqlParameter();
    //SqlParameter param1 = new SqlParameter();
    param.ParameterName = "@userid";
    param.ParameterName = "@reg";
    param.Value = txtid.Text;
    param.Value = txtregNo.Text;
    cmdd.Parameters.Add(param);
