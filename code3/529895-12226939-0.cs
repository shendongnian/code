    using System;
    using System.Windows.Forms;
    using System.Data.OleDb;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string connectionString;
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;";
                connectionString += "Data Source=C:\\Temp\\Database1.mdb";
    
                using (var connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
    
                    var command = connection.CreateCommand();
                    command.CommandText =
                        "UPDATE Table1 SET Replaceme = ? WHERE Searchme = ?";
    
                    var p1 = command.CreateParameter();
                    p1.Value = "Goodman";
                    command.Parameters.Add(p1);
    
                    var p2 = command.CreateParameter();
                    p2.Value = "Anand";
                    command.Parameters.Add(p2);
    
                    var result = String.Format("Records affected: {0}",
                        command.ExecuteNonQuery());
                    MessageBox.Show(result);
                }
            }
        }
    }
