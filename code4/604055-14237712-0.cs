    using System.Data.OleDb;
    
                string strCon = Properties.Settings.Default.PID2dbConnectionString;
                OleDbConnection conn = new OleDbConnection(strCon);
                try {
                    conn.Open();
                    string strSql = "Select forename,surname from customer where customer id ='" + txtName.Text + "'";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    comboBox1.DataSource = ds.Tables[0];
                    comboBox1.DisplayMember = "forename";
                    comboBox1.ValueMember = "surname";
                }
                finally {
                    conn.Close();
                }
