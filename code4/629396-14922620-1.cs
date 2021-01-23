        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            var idOrdinal = reader.GetOrdinal("ID");
            //extract other ordinal positions and store here
            
            while (reader.Read())
            {
                var id = reader.GetInt32(idOrdinal);
                
                if (!AuthorDict.ContainsKey(id))
                {
                    Author author = new Author();
                    author.id = reader.GetInt32(idOrdinal);
                    ...
                }
            }
        }
