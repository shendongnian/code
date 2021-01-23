    string myConnectionStringMDB =
            "Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=C:\Users\Gord\Desktop\fromCE.mdb;";
    string myConnectionStringSQL =
            "Provider=Microsoft.SQLSERVER.CE.OLEDB.3.5;" +
            @"Data Source=C:\Users\Public\test\myData.sdf;";
    using (OleDbConnection conSQL = new OleDbConnection(),
            conMDB = new OleDbConnection())
    {
        conSQL.ConnectionString = myConnectionStringSQL;
        conSQL.Open();
        conMDB.ConnectionString = myConnectionStringMDB;
        conMDB.Open();
        using (OleDbCommand cmdSQL = new OleDbCommand(),
                cmdMDB = new OleDbCommand())
        {
            cmdSQL.CommandType = System.Data.CommandType.Text;
            cmdSQL.Connection = conSQL;
            cmdSQL.CommandText = "SELECT * FROM [Table1]";
            var daSQL = new System.Data.OleDb.OleDbDataAdapter(cmdSQL);
            var dt = new System.Data.DataTable();
            daSQL.Fill(dt);
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                // change row status from "Unchanged" to "Added" so .Update below will insert them
                dr.SetAdded();
            }
            cmdMDB.CommandType = System.Data.CommandType.Text;
            cmdMDB.Connection = conMDB;
            cmdMDB.CommandText = "SELECT * FROM [Table1]";
            var daMDB = new System.Data.OleDb.OleDbDataAdapter(cmdMDB);
            var cbuilderMDB = new OleDbCommandBuilder(daMDB);
            cbuilderMDB.QuotePrefix = "[";
            cbuilderMDB.QuoteSuffix = "]";
            daMDB.Update(dt);
        }
        conSQL.Close();
        conMDB.Close();
    }
