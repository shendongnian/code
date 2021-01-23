    var csvParams = (from line in System.IO.File.ReadLines("fileName.csv")
                from cell in line.Split(',').AsEnumerable()
                select new[]
                {
                    new OleDbParameter("@fn", cell[1]),
                    new OleDbParameter("@ln", cell[2]),
                    new OleDbParameter("@sn", cell[3]),
                    new OleDbParameter("@zc", cell[4])
                });
    using( OleDbConnection conn = new OleDbConnection("CONNECTION STRING GOES HERE"))
    {
        foreach (var person in csvParams)
        {
            using (OleDbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO People(FirstName, LastName, S_NO, zip_code) VALUES (@fn, @ln, @sn, @zc)";
                cmd.Parameters.AddRange( (OleDbParameter[]) person);
                cmd.ExecuteNonQuery();
            }
                    
        }
    }
