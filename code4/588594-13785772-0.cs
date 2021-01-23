     class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection connection = new SQLiteConnection(@"Data Source = C:\APTRABuilder.sqlite;Version=3;");
            connection.Open();
            string conncommand = "Select language1 from builderScreenResourceBundleTBL";
            SQLiteCommand cmd = new SQLiteCommand(conncommand, connection);
            DataReader dr = cmd.ExecuteReader()
            while(dr.Read())
               {
                 //fetch the Rows here.
               }
        }
    }
