    using System;
    using System.Data;
    using System.Data.OleDb;
    
    namespace AccessDb
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = SelectALL("SELECT * FROM QuickMem");
                Console.WriteLine("Done");
                Console.ReadKey();
            }
    
            public static DataTable SelectALL(string SQL)
            {
                //var appDataPath = Environment.GetFolderPath(
                                       Environment.SpecialFolder.ApplicationData);
                //var dbPath = System.IO.Path.Combine(appDataPath, "Dropbox\\host.db");    
                //var lines = System.IO.File.ReadAllLines(dbPath);
                //var dbBase64Text = Convert.FromBase64String(lines[1]);
                //string folderPath = System.Text.ASCIIEncoding.ASCII.GetString(dbBase64Text);
    
                string folderPath = "C:\\Users\\drook\\Documents\\Database1.accdb";    
                string strAccessConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + folderPath;    
                string strAccessSelect = SQL;    
                DataSet myDataSet = new DataSet();
                OleDbConnection myAccessConn = null;    
                myAccessConn = new OleDbConnection(strAccessConn);    
                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);
    
                myAccessConn.Open();    
                myDataAdapter.Fill(myDataSet, "QuickMem");    
                myAccessConn.Close();
    
                DataTableCollection dta = myDataSet.Tables;
                return dta[0];    
            }
        }
    }
