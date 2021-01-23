    private static void TestingCommandTimeOutInMySql()
            {
                string connetionString = "Server=localhost;Database=sakila;Uid=root;Pwd=Passw0rd;default command timeout=40;";
                MySqlConnection con = new MySqlConnection(connetionString);
                try
                {
                    cnn.Open();
                    Console.WriteLine("Connection Open ! ");
                    MySqlCommand cmd = new MySqlCommand("select * from actor", con);
                    var timeoutValue = cmd.CommandTimeout; //shows 40
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }
            }
