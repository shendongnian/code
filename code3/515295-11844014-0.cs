    using Npgsql;
    namespace DBPrj
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool boolfound=false;
                using(NpgsqlConnection conn = new NpgsqlConnection("Server=<ip>; Port=5432; User Id=Admin; Password=postgres.1; Database=Test1"))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Table1", con);
                    NpgsqlDataReader dr= cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        boolfound=true;
                        Console.WriteLine("connection established");
                    }
                    if(boolfound==false)
                    {
                        Console.WriteLine("Data does not exist");
                    }
                    dr.Close();
                }
            }
        }
    }
