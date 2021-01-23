    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MySql.Data.MySqlClient;
    using System.Data.SqlClient;
    
    namespace ConsoleApplication2
    {
    
        class Program
        {
            public static void Main()
            {
                string myConnectionString = "SERVER=50.62.82.40;" +
                                "DATABASE=db_admin;" +
                                "UID=db_usr;" +
                                "PASSWORD=wowow`enter code here`;";
    
                MySqlConnection connection = new MySqlConnection(myConnectionString);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SHOW TABLES;";
                MySqlDataReader Reader;
                connection.Open();
                Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    string row = "";
                    for (int i = 0; i < Reader.FieldCount; i++)
                        row += Reader.GetValue(i).ToString() + ", ";
                    Console.WriteLine(row);
                }
                connection.Close();
                Console.ReadLine();
            }
        }
    }
