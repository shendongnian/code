    using(SqlDataReader sdr = cmd1.ExecuteReader())
    {
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Console.WriteLine(sdr.GetString(0) +" at " + sdr.GetInt32(1));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
    }
