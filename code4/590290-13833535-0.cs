    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.OleDb;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data
                    Source=C:\Users\James\Desktop\Programming\2004RAW.accdb";
                
                    string query = "SELECT FIRST_NAME FROM 2004RAW";
                GetQuery(query, connectionString);
            }
            public void GetQuery(string query, string connectionString)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(query, connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["FIRST_NAME"]);
                    }
                    reader.Close();
                }
            }
        }
    }
