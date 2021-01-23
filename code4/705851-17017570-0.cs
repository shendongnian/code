    string str = string.Format("Update TblMasterinfo SET AppLoanStatus=@AppLoanStatus Where appid in ({0})",txtStatusChange.Text);
    using (SqlCommand com = new SqlCommand(str, conn))
    {
    	com.Parameters.AddWithValue("@Statuschange", Convert.ToInt32(txtStatusChange.Text));
    	com.ExecuteNonQuery();
    }
