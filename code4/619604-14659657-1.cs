    using (StreamWriter textwriterISO = new StreamWriter(path + "_out.XML", false, Encoding.GetEncoding("ISO-8859-1")))
    {                                  
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        Console.WriteLine("Writing results.This could take a very long time.");
        while (sqlDataReader.Read())
        {
            for (int i = 0; i < sqlDataReader.FieldCount; i++)
            {
                // you were originally calling the WriteLine(String, Object) overload.
                // Are you sure you want to call that? It interprets the first parameter
                // as a pattern to format the value of the second parameter. A DB column
                // name is not a formatting pattern!
                textwriterISO.WriteLine(sqlDataReader.GetName(i), sqlDataReader[i].ToString());
                // perhaps you meant to write the DB column name and field value separately?
                //
                // textwriterISO.WriteLine(sqlDataReader.GetName(i));
                // textwriterISO.WriteLine(sqlDataReader[i].ToString());
            }
            textwriterISO.Flush();
        }
    }
