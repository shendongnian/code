    static String Server = "";
    static String Username = "";
    static String Name = "";
    static String password = "";
    static String conString = "SERVER=" + Server + ";DATABASE=" + Name + ";UID=" + Username  + ";PASSWORD=" + password + ";connect timeout=500000;Compress=true;";
    public bool InsertSQL(String Query)
    {
       int tmp = 0;
       try
       {
          using (MySqlConnection mycon = new MySqlConnection(conString))
          {
             using (MySqlCommand cmd = new MySqlCommand(Query, mycon))
             {
                mycon.Open();
                try
                {
                    cmd.Parameters.AddWithValue("@queryParam", Query);
                    tmp = cmd.ExecuteNonQuery();
                }
                
                catch
                {
                    if (mycon.State == ConnectionState.Open)
                    {
                        mycon.Close();
                    }
                }
                mycon.Close();
             }
         }
     }
     catch { return tmp > 0 == true ? true : false; }
     return tmp > 0 == true ? true : false;
   }
