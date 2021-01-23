            var rdr = cmd.ExecuteReader();
            while (rdr.Read()) {
                if (!(rdr["Id"] is DBNull))
                {
                    Console.WriteLine(rdr["Id"] + " ");
                }
                if (!(rdr["Name"] is DBNull))
                {
                    Console.WriteLine(rdr["Name"] + " ");
                }
                if (!(rdr["Family"] is DBNull))
                {
                    Console.WriteLine(rdr["Family"] + " ");
                }
            }
