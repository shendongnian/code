     public class sqlConn
    {
        public SqlConnection myConnection;
        public void connectionMethod()
        {
            myConnection = new SqlConnection("user id=ID;password=PASS;server=SERVER;database=DB;");
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
