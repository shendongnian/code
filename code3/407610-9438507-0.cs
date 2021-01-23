    private void button1_Click(object sender, EventArgs e)
        {
            ServerConnection connection = new ServerConnection("stjepan-lap");
            connection.LoginSecure = true;
            Server server = new Server(connection);
            server.ConnectionContext.InfoMessage += new SqlInfoMessageEventHandler(ConnectionContext_InfoMessage);
            server.ConnectionContext.StatementExecuted += new StatementEventHandler(ConnectionContext_StatementExecuted);
            server.ConnectionContext.ServerMessage += new ServerMessageEventHandler(ConnectionContext_ServerMessage);
            //Executes T-Sql script
            try
            {
                server.ConnectionContext.ExecuteNonQuery(textBox1.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                if (ex.InnerException != null)
                    Debug.WriteLine(ex.InnerException.Message);
            }
            server.ConnectionContext.Disconnect();
        }
        void ConnectionContext_ServerMessage(object sender, ServerMessageEventArgs e)
        {
            Debug.WriteLine(e.Error);
        }
        void ConnectionContext_StatementExecuted(object sender, StatementEventArgs e)
        {
            Debug.WriteLine(e.SqlStatement);
        }
        void ConnectionContext_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }
