    // include Dapper from nuget
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using Dapper;
    using System.Diagnostics;
    
    namespace ConsoleApplication16
    {
        class Program
        {
            static void Main(string[] args)
            {
                var cnn = new SqlConnection("Data Source=.;Initial Catalog=tempdb;Integrated Security=True");
                cnn.Open();
    
                cnn.Execute("create table #t(num int, str nvarchar(50))");
    
                // 10 k records
                cnn.Execute("insert #t values (@num, @str)", 
                    Enumerable.Range(1, 10000).Select(i => new { num = i, str = Guid.NewGuid().ToString() }));
    
                Stopwatch sw;
    
                SqlCommand cmd = new SqlCommand("select * from #t");
                cmd.Connection = cnn;
    
                for (int i = 0; i < 10; i++)
                {
                    sw = Stopwatch.StartNew();
                    using (var reader = cmd.ExecuteReader())
                    {
                        int num;
                        string str;
                        while (reader.Read())
                        {
                            num = reader.GetInt32(0);
                            str = reader.GetString(1);
                        }
                    }
                    Console.WriteLine("GetXYZ {0}", sw.ElapsedTicks);
    
                    sw = Stopwatch.StartNew();
                    using (var reader = cmd.ExecuteReader())
                    {
                        int num;
                        string str;
                        while (reader.Read())
                        {
                            num = (int)reader.GetValue(0);
                            str = (string)reader.GetValue(1);
                        }
                    }
                    Console.WriteLine("GetValue {0}", sw.ElapsedTicks);
                }
    
                Console.ReadKey();
            }
        }
    }
