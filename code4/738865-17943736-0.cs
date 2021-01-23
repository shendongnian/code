    else if (period.ToString().Equals("3 years")&&Session["@loanID"]!=null)
    {
        for (int i = 0; i <= 36; i++)
        {
            string strCommandText5 = "INSERT INTO AutoTrans VALUES(@loanID,@transPeriod,null,@transStatus);";
            SqlCommand myCommand5 = new SqlCommand(strCommandText5, myConnection);
            myCommand5.Parameters.AddWithValue("@loanID", Session["@loanID"].ToString());
            myCommand5.Parameters.AddWithValue("@transPeriod", numPeriod);
            myCommand5.Parameters.AddWithValue("@transStatus", status);
            numPeriod++;
            myCommand5.ExecuteNonQuery();
        }
    }
