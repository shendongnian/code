    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main()
            {
                CallProcedure( CommandType.Text );
                CallProcedure( CommandType.StoredProcedure );
            }
    
            private static void CallProcedure(CommandType commandType)
            {
                using ( SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Test;Integrated Security=SSPI;") )
                {
                    connection.Open();
                    using ( SqlCommand textCommand = new SqlCommand("dbo.Test", connection) )
                    {
                        textCommand.CommandType = commandType;
                        textCommand.Parameters.AddWithValue("@Text1", "Text1");
                        textCommand.Parameters.AddWithValue("@Text2", "Text2");
                        using ( IDataReader reader = textCommand.ExecuteReader() )
                        {
                            while ( reader.Read() )
                            {
                                Console.WriteLine(reader["Text1"] + " " + reader["Text2"]);
                            }
                        }
                    }
                }
            }
        }
    }
