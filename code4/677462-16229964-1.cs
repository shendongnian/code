     private Int32 RollBackTheWholetransaction(String DbName, Int32 HospitalId)
    {
        Int32 result = 0;
        try
        {
            String Connectionstring = CCMMUtility.CreateConnectionString(false, txt_DbDataSource.Text, "master", "sa", "happytimes", 1000);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Connectionstring;
            String sqlCommandText = "ALTER DATABASE [" + DbName + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
            String sqlCommandText1 = "DROP DATABASE [" + DbName + "]";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlConnection.ClearPool(con);
                con.ChangeDatabase("master");
                SqlCommand sqlCommand = new SqlCommand(sqlCommandText, con);
                sqlCommand.ExecuteNonQuery();
                SqlCommand sqlCommand1 = new SqlCommand(sqlCommandText1, con);
                sqlCommand1.ExecuteNonQuery();
                ClsHospitals objHospiitals = new ClsHospitals();
                String resultDbdelete = objHospiitals.DeleteHospital(HospitalId, Session["devSuperAdmin"].ToString());
                if (resultDbdelete == "1")
                {
                    result = 1;
                }
                else
                {
                    result = 2;
                }
            }
            else
            {
                SqlConnection.ClearPool(con);
                con.ChangeDatabase("master");
                SqlCommand sqlCommand = new SqlCommand(sqlCommandText, con);
                sqlCommand.ExecuteNonQuery();
                SqlCommand sqlCommand1 = new SqlCommand(sqlCommandText1, con);
                sqlCommand1.ExecuteNonQuery();
            }
            con.Close();
            con.Dispose();
            result = 1;
        }
        catch (Exception ex)
        {
            result = 0;
        }
        return result;
    }
