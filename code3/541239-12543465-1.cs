    use conn = ???
    conn.Open()
    using new SqlCommand("dbo.query_here", conn)(fun cmd ->
        
        cmd.CommandText <- "dbo.query_here"
        cmd.CommandType <- System.Data.CommandType.StoredProcedure
        cmd.CommandTimeout <- 600
        cmd.Parameters.Add(new SqlParameter("@x1", Convert.ToString(x)))
        cmd.Parameters.Add(new SqlParameter("@y1", y))
        cmd.Parameters.Add(new SqlParameter("@z1", z))
        let reader = cmd.ExecuteReader()
        while (reader.Read()) do
            MyListOfClasses.Add(new MyDataClass(reader.GetInt32(reader.GetOrdinal("x"))           
                                                reader.GetDouble(reader.GetOrdinal("y")),
                                                reader.GetDouble(reader.GetOrdinal("a")),
                                                reader.GetDouble(reader.GetOrdinal("b"))))
        
        reader.Close()
    )
    conn.Close()
    MyListOfClasses.ToArray() |> List.ofArray
