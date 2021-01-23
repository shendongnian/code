    using System.Data.Odbc;
    string connectionString = "DRIVER={MySQL ODBC 5.1 Driver}; SERVER=localhost;  
    DATABASE=dbname; UID=myuserid; PASSWORD=mypassword;OPTION=3; POOLING=false;";
    OdbcConnection DBCon = new OdbcConnection(connectionString);
    if (DBCon.State == ConnectionState.Open)
    {
        DBCon.Close();
    }
    DBCon.Open();
    MessageBox.Show ("Connection Open ! ");
    DBCon.Close();
