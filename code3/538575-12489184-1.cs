           //your connection string here 
            SqlConnection con = RobCS_109.RDB.HentlConn;
        
            con.Open();
            string updateCMD = dsWorkDayPerMonth.UpdateCommand;
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            //use a select command and SqlConnection
            da = new SqlDataAdapter(dsWorkDayPerMonth.SelectCommand, con);
            //same here i have used all values recived in the example(top one)code
            // event -RowUpdating above, then i am using
           //stored sqlUpdate string for the command below
            da.UpdateCommand = new SqlCommand(SQLUP);
            da.Fill(ds, "tblWorkDayPerMonth");
            dsWorkDayPerMonth.Update();
            con.Close();
