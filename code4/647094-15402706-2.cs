    using System;
    using System.Data.SQLite;
    using System.Threading.Tasks;
    namespace SQLiteTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var tasks = new Task[100];
            
                for (int i = 0; i < 100; i++)
                {
                    tasks[i] = new Task(new Program().WriteToDB);
                    tasks[i].Start();
                }
                foreach (var task in tasks)
                    task.Wait();
            }
            public void WriteToDB()
            {
                try
                {
                    using (SQLiteConnection myconnection = new SQLiteConnection(@"Data Source=c:\123.db"))
                    {
                        myconnection.Open();
                        using (SQLiteTransaction mytransaction = myconnection.BeginTransaction())
                        {
                            using (SQLiteCommand mycommand = new SQLiteCommand(myconnection))
                            {
                                Guid id = Guid.NewGuid();
                                mycommand.CommandText = "INSERT INTO Categories(ID, Name) VALUES ('" + id.ToString() + "', '111')";
                                mycommand.ExecuteNonQuery();
                                mycommand.CommandText = "UPDATE Categories SET Name='222' WHERE ID='" + id.ToString() + "'";
                                mycommand.ExecuteNonQuery();
                                mycommand.CommandText = "DELETE FROM Categories WHERE ID='" + id.ToString() + "'";
                                mycommand.ExecuteNonQuery();
                            }
                            mytransaction.Commit();
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    if (ex.ReturnCode == SQLiteErrorCode.Busy)
                        Console.WriteLine("Database is locked by another process!");
                }
            }
        }
    }
