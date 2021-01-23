    OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider=MSDAORA;Data Source=oracle;Persist Security Info=True;User ID=system;Password=**********;Unicode=True";
                
                OleDbCommand comd1 = new OleDbCommand("select name from table", con);
                OleDbDataReader DR = comd1.ExecuteReader();
                while (DR.Read())
                {
                    comboBox_delete.Items.Add(DR[0]);
                }
                con.Close();
