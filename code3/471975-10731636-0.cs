    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <appSettings>
        <add key="connectstring" value="Data Source=server111;Initial Catalog=database1;        Integrated Security=False;Persist Security Info=False; User ID=username;Password=password;Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True"/>
      </appSettings>
    </configuration>
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using System.Configuration;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    SqlConnection connStudent;
                    connStudent = new SqlConnection(ConfigurationManager.AppSettings["connectstring"].ToString());
                    //connStudent.Open();
                    //connStudent.Close();
                    Console.WriteLine("ok");
                }
                catch
                {
                    Console.WriteLine("error");
                }
            }
    
        }
    }
