    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
        <startup> 
            <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0"/>
        </startup>
    </configuration>
     /////////the below code is a sample from oracle company////////////////
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Common;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Oracle.ManagedDataAccess.Client;
    ///copy these lines in a button click event 
        string constr = "User Id=system; Password=manager; Data Source=orcl;";
    // Click here and then press F9 to insert a breakpoint
            DbProviderFactory factory =
        DbProviderFactories.GetFactory("Oracle.ManagedDataAccess.Client");
                using (DbConnection conn = factory.CreateConnection())
                {
                    conn.ConnectionString = constr;
                    try
                    {
                        conn.Open();
                        OracleCommand cmd = (OracleCommand)factory.CreateCommand();
                        cmd.Connection = (OracleConnection)conn;
    //to gain access to ROWIDs of the table
    //cmd.AddRowid = true;
                        cmd.CommandText = "select * from all_users";
    
                        OracleDataReader reader = cmd.ExecuteReader();
    
                        int visFC = reader.VisibleFieldCount; //Results in 2
                        int hidFC = reader.HiddenFieldCount;  // Results in 1
                        MessageBox.Show(" Visible field count: " + visFC);
    
                        MessageBox.Show(" Hidden field count: " + hidFC);
                        
    
                        reader.Dispose();
                        cmd.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                          MessageBox.Show(ex.StackTrace);
                    }
                }
