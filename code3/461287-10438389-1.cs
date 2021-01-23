          FbConnectionStringBuilder csb = new FbConnectionStringBuilder( );
          csb.ServerType = FbServerType.Default;
          csb.Database = Settings.Default.LastBDPath;
          csb.Password = Settings.Default.LastBDPassword; //            "masterkey";
          csb.UserID = Settings.Default.LastBDUser;       //            "SYSDBA";
          connection = new FbConnection( csb.ToString( ) );
          connection.Open( ); 
           
          string scriptLine = string.Format("INSERT INTO TABLE (Id, Name, Score) values ({0}, '{1}', {2}", zId+1, var, score) ; 
          FBCommand command = new FbCommand( scriptline, connection );
          command.ExecuteNonQuery( );
