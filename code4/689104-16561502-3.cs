    using System;
    using System.Data;
    using System.Data.OleDb;
    
    namespace AccessDb
    {
        class Program
        {
            static void Main(string[] args)
            {
                string folderPath = "C:\\Users\\drook\\Documents\\Database1.accdb";
                string strAccessConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + folderPath;
                DataSet myDataSet = new DataSet();
                OleDbConnection myAccessConn = null;
                myAccessConn = new OleDbConnection(strAccessConn);
                myAccessConn.Open();
                myAccessConn.Close();
                Console.WriteLine("All done");
                Console.ReadKey();
            }
        }
    }
