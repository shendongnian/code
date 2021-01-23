     public class sqlConn
        {
            public SqlConnection myConnection = new SqlConnection("user id=ID;password=PASS;server=SERVER;database=DB;");
            public void connectionMethod()
            {
                
                try
                {
                    myConnection.Open();
                }
                catch
                {
                    //MessageBox.Show("Невозможно подключиться к Базе данных. Пожалуйста обратитесь к программистам!", "Ошибка подключения к Базе данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myConnection.Close();
                }
            }
        }
