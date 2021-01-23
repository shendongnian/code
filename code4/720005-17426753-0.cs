    class Datatbl_Class1
    {
        public DataSet filldata(string q )
        {
            string myconnection = "datasource=localhost;port=3306;username = root; password = 12345V";
            MySqlConnection con = new MySqlConnection(myconnection);
            MySqlCommand cmd = new MySqlCommand(q, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
    
            DataSet ReturnThisOne = new DataSet();
            da.Fill(ReturnThisOne);
            return ReturnThisOne;
        }
    }
