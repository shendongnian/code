    SomeClass
    {
       public static MySqlConnection CreateConnection()
       {
           MySqlConnection mycon = new MySqlConnection();
           mycon.ConnectionString = "Connection";
           mycon.Open();
           return mycon;
       }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        using (MySqlConnection conn = SomeClass.CreateConnection())
        {
        }
    }
