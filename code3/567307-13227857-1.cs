    string sqlConnectionString = "Data Source=(local);Initial Catalog=AdventureWorks;Integrated Security=True";
                FileInfo file = new FileInfo("C:\\myscript.sql");
                string script = file.OpenText().ReadToEnd();
                SqlConnection conn = new SqlConnection(sqlConnectionString);
                Server server = new Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(script);
