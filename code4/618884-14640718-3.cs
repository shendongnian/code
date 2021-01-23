    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlParameter para = new SqlParameter();
    
    ReportDocument report = new ReportDocument();
    ConnectionInfo conInfo = new ConnectionInfo();
        
    con.Open();
    cmd = new SqlCommand("spGetResultdriver", con);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DATATYPE, LENGTH, "From"));
    cmd.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DATATYPE, LENGTH, "To"));
    cmd.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.DATATYPE, LENGTH, "Location"));
    cmd.Parameters.Add(new SqlParameter("@ShowDriversUsing", SqlDbType.DATATYPE, LENGTH, "Location"));
    cmd.Parameters.Add(new SqlParameter("@SigDate", SqlDbType.DATATYPE, LENGTH, "Location"));
    
    cmd.Parameters[0].Value = dtpFrom.Text;
    cmd.Parameters[1].Value = dtpTo.Text;
    cmd.Parameters[2].Value = cbCityCode.Text;
    cmd.Parameters[3].Value = dtpTo.Text;
    cmd.Parameters[4].Value = cbCityCode.Text;
    
    conInfo.DatabaseName = "db name";
    conInfo.UserID = "user id";
    conInfo.Password = "password";
    int i = cmd.ExecuteNonQuery();
    con.Close();
    
    report.Load("report path");
    SetDBLogonForReport(conInfo, report);
    crvReports.ReportSource = report;
    crvReports.Refresh();
