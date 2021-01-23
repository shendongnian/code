    String Connectionstring = CCMMUtility.CreateConnectionString(false, txt_DbDataSource.Text, "master", "sa", "happytimes", 1000);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Connectionstring;
            bool resultdbexistencx = CCMMUtility.CheckDatabaseExists(con, txt_DbName.Text);
            if (!resultdbexistencx)
            {
                // if not exists create it check the user name for sub-admin avialibe or not.
                if (txt_DbName.Text.Trim() == string.Empty) return;
                string strDbCreate;
                strDbCreate = "CREATE DATABASE " + txt_DbName.Text + " ON PRIMARY " +
                "(NAME = " + txt_DbName.Text + "_Data, " +
                "FILENAME = 'D:\\" + txt_DbName.Text + "Data.mdf', " +
                "SIZE = 4MB, MAXSIZE = 10GB, FILEGROWTH = 100%) " +
                "LOG ON (NAME = " + txt_DbName.Text + "_Log, " +
                "FILENAME = 'D:\\" + txt_DbName.Text + ".ldf', " +
                "SIZE = 4MB, " +
                "MAXSIZE = 10GB, " +
                "FILEGROWTH = 100%)";
                SqlConnection sqlconn = new SqlConnection(Connectionstring);
                SqlCommand cmd = new SqlCommand(strDbCreate, sqlconn);
                try
                {
                    sqlconn.Open();
                    sqlconn.ChangeDatabase("master");
                    cmd.ExecuteNonQuery();
                }
               catch (Exception ex)
                {
                    Int32 dbRollbackResult = RollBackTheWholetransaction(txt_DbName.Text.Trim(), Convert.ToInt32(HospitalResult));
                    if (dbRollbackResult == 1)
                    {
                        Response.Write(ex.Message);
                        lblMessage.DisplayMessage(StatusMessages.ErrorMessage, "There is some problem while generating the database or database name doesn't avialible.");
                    }
                 }
