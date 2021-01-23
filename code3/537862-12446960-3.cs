    class Program 
    {
        static void Main(string[] args) 
        {
            DataTable CasTable = fillSampleDataTable("SELECT top 100 * FROM x");
            //do other stuff
        }
        static DataTable fillSampleDataTable(string myCommand) 
        {
            var connectionString = ConfigurationManager.ConnectionStrings["XXX"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            using (var adapt = new SqlDataAdapter(cmd, conn)) 
            {
                conn.Open();
                cmd.CommandText = myCommand;
                DataSet mySet = new DataSet();
                adapt.Fill(mySet, "SampleData");
                return mySet.Tables["SampleData"];
            }
        }
    }
