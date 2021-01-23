           try
            {
                MySqlConnection mysqlCon = new MySqlConnection(mysqlProv);
                mysqlCon.Open();
                MySqlCommand MyDA = new MySqlCommand(mysqlIns1, mysqlCon);
                MyDA.ExecuteNonQuery();
                MessageBox.Show("Success!");
                mysqlCon.Close();
            }
            catch
            {
                MessageBox.Show("Error Occured Please Try Again");
            }
