    string input ="17110,17147,17524,17736,15906,17268,16440,17241";
    string str = string.Format("Update TblMasterinfo SET AppLoanStatus=@AppLoanStatus Where appid in ({0})",input);
    using (SqlCommand com = new SqlCommand(str, conn))
    {
    	com.Parameters.AddWithValue("@Statuschange", Convert.ToInt32(txtStatusChange.Text));
    	com.ExecuteNonQuery();
    }
