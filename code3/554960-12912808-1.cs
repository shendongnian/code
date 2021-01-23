    class Program
            {
                static void Main(string[] args)
                {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+"C:\\Users\\123\\Desktop\\plan1.xlsx;"+"Extended Properties=\"Excel 12.0;ReadOnly=False;HDR=Yes\";";
                // here you can use your text box or from
                // where ever you access the data to be inserted
                // into the that Excel file sheet
                string selectString = "INSERT INTO [Sheet1$] ([ID], [NAME], [DESCRIPTION], [SQL_CODE]) VALUES ('1','maziz','Not working','selectfrom you')";
        
                OleDbConnection con = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand(selectString, con);
        
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Successfully inserted the records");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
        	       con.Close();
                   con.Dispose();
                }
                Console.ReadLine();
                }
            }
