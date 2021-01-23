    public static class SQLTest
        {
            public static void NpgsqlCommand()
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server = ; Port = ; User Id = ; " + "Password = ; Database = ;"))
                {
                    NpgsqlCommand command1 = new NpgsqlCommand("update xy set xw = 'a' WHERE aa='bb'", connection);
                    NpgsqlCommand command2 = new NpgsqlCommand("update xy set xw = 'b' where bb = 'cc'", connection);
                    command1.Connection.Open();
                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    command2.Connection.Close();
                }
            }
        }
