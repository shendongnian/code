    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
    using Oracle.DataAccess.Types;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string oradb = "Data Source=OMP1;User Id=user;Password=pass;";
                using(OracleConnection conn = new OracleConnection(oradb))
                using(OracleCommand cmd = new OracleCommand("SELECT Count(*) as trig FROM table", conn))
                {
                    conn.Open();
                    int cnt = (int)cmd.ExecuteScalar();
                    if (cnt > 0)
                    {
                        System.Diagnostics.Process.Start(@"C:\testfile.bat");
                    }
                }
            }
        }
    }
