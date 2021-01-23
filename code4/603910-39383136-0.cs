            using(SqlConnection sc = new SqlConnection(connStr))
            {
                sc.InfoMessage += new SqlInfoMessageEventHandler(sc_InfoMessage);
                Server db = new Server(new ServerConnection(sc));
                db.ConnectionContext.ExecuteNonQuery(commandFileText, ExecutionTypes.ContinueOnError); 
            }
