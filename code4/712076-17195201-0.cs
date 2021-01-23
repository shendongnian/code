    public static bool checkDB_Conn()
    {
        var conn_info = "Server=address;Port=3306;Database=dbhere;Uid=admin;Pwd=123";
        bool isConn = false;
        MySqlConnection conn = null;
        try
        {
            conn = new MySqlConnection(conn_info);
            conn.Open();
            isConn = true;
        }
        catch (ArgumentException a_ex)
        {
            /*
            Console.WriteLine("Check the Connection String.");
            Console.WriteLine(a_ex.Message);
            Console.WriteLine(a_ex.ToString());
            */
        }
        catch (MySqlException ex)
        {
            /*string sqlErrorMessage = "Message: " + ex.Message + "\n" +
            "Source: " + ex.Source + "\n" +
            "Number: " + ex.Number;
            Console.WriteLine(sqlErrorMessage);
            */
            isConn = false;
            switch (ex.Number)
            {
                //http://dev.mysql.com/doc/refman/5.0/en/error-messages-server.html
                case 1042: // Unable to connect to any of the specified MySQL hosts (Check Server,Port)
                    break;
                case 0: // Access denied (Check DB name,username,password)
                    break;
                default:
                    break;
            }
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        return isConn;
    }
