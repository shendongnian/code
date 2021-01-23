    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Oracle.DataAccess.Client;
    using System.IO;
    
    
    namespace execsql
    {
        /// <summary>
        /// Simple Sql Executor for use in Batch files.
        /// ExitCode = 0 on success
        /// </summary>
        class Program
        {
            private static string _sql;
    
            static void Main(string[] args)
            {
                try
                {
                    if (CheckArgs(args))
                    { 
                        ExecuteSql(args);
                        Console.WriteLine("execsql Ok");
                        Console.WriteLine(_sql);
                    }
                }
                catch (Exception ex)
                {
                    Environment.ExitCode = 2;
                    Console.WriteLine("ExecSql Encountered an Error");
                    Console.WriteLine(_sql);
                    Console.WriteLine(ex.Message);
                }
    
            }
    
            private static void ExecuteSql(string[] args)
            {
                LoadSql(args);
    
                using (OracleConnection conn = GetConnection(args))
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
    
                    cmd.CommandText = _sql;
                    cmd.ExecuteNonQuery(); 
                }
            }
    
            private static void LoadSql(string[] args)
            { 
                if (args[3].StartsWith("/f=")) // not tested
                {
                    StringBuilder script = new StringBuilder();
                    string fname = args[3].Split('=')[1];
    
                    string[] strings = File.ReadAllLines(fname);
    
                    foreach(string str in strings)
                        script.Append(str);
    
                    _sql = script.ToString();
                }
                else
                {
                    _sql = args[3];
                }
            }
    
            private static bool CheckArgs(string[] args)
            {
                if (args.Count() == 4)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid Number Of Arguments - Expected 4");
                    Console.WriteLine("Use : execsql <dbServer> <dbUser> <dbPassword> <sql>");
                    Environment.ExitCode = 1;
                    return false;
                }
            }
    
            private static OracleConnection GetConnection(string[] args)
            { 
                string connectionString = String.Format("Data Source={0};User ID={1};Password={2}", args[0], args[1], args[2]); 
                return new OracleConnection(connectionString);
            }
        }
    }
