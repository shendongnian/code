    public void PopulateDatabaseNames(string connectionString, ComboBox cboDBNames)
    {
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        SqlConnection cnn = null;
        try
        {
            using(cnn = new SqlConnection(connectionString))
            using(cmd = new SqlCommand())
            using(da = new SqlDataAdapter())
            {
                cnn.Open();
                cmd.CommandText = "SELECT NAME FROM master..sysdatabases order by NAME";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                SqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    string name = myReader.GetString(0).ToLower();
                    if (name != "master" && name != "tempdb" && name != "model" && name != "msdb")
                    {
                        cboDBNames.Items.Add(name);
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            MessageBox.Show(e.Message, "PopulateDatabasesNames");
        }
    }
