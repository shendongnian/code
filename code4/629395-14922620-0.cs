        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            var idOrdinal = reader.GetOrdinal("ID");
            while (reader.Read())
            {
                var id = reader.GetInt32(idOrdinal);
                //extract other ordinal positions and store here
 
                if (!AuthorDict.ContainsKey(id))
                {
                    Author author = new Author();
                    author.id = reader.GetInt32(idOrdinal);
                    ...
                }
            }
        }
