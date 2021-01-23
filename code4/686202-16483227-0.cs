    string str =@"SELECT COUNT(*) FROM [CompaniesDB].[dbo].[Companies] WHERE BolagsID = '" + BolagsID + "'";
    using (SqlConnection conn = new SqlConnection("user id=user;" + "password=pass;" + "server=server;" + "database=db;"))
    {
       using (SqlCommand comm = new SqlCommand(str))
       {
          conn.Open();
          comm.Connection = conn;
          MessageBox.Show("TEST: {0}", Convert.ToString((int)comm.ExecuteScalar()));
       }
    }
