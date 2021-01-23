    this code For Restore Database,Please Type Code In C#:
    
    SqlConnection ObjConnection=new SqlConnection("Your Connection String");
    ObjConnection.Open();
                    SqlCommand ObjCommand = new SqlCommand();
                    ObjCommand.Connection = ObjConnection;
                    ObjCommand.CommandText = "Use Master   ALTER DATABASE YourDatabaseName SET                 OFFLINE WITH ROLLBACK IMMEDIATE  " +
                    "Restore Database YourDatabaseName From Disk='" + LblPath.Text + "'" +
                    "   ALTER DATABASE YourDatabaseName SET ONLINE WITH ROLLBACK IMMEDIATE";
                    ObjCommand.CommandType = CommandType.Text;
                    ObjCommand.ExecuteNonQuery();
    Help:LblPath.Text is a Label Control Contain Path Backup Database You!
    Mojtaba From IRAN
