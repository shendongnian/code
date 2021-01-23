    var conString = System.Configuration.ConfigurationManager.ConnectionStrings["CONSTRING"];
    string strConnString = conString.ConnectionString;
    SqlConnection cs = new SqlConnection(strConnString);
            try
            {
                cs.Open();
                String sqlquery = "Use Master ALTER DATABASE databasename SET OFFLINE WITH ROLLBACK IMMEDIATE RESTORE DATABASE databasename FROM DISK ='" + txtRestoreFileLoc.Text + "' ALTER DATABASE databasename SET ONLINE WITH ROLLBACK IMMEDIATE";
                SqlCommand cmd = new SqlCommand(sqlquery, cs);
                cmd.ExecuteNonQuery();
                cs.Close();
                cs.Dispose();
                MessageBox.Show("restore complete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
