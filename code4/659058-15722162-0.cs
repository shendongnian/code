            var fname = "File12.txt";
            var keywords = new List<string>(new[]{ "dog", "cat", "moose" });           
            
            var miXML = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("root"));
            foreach (var el in keywords.Select(i => new XElement("item", new XAttribute("key", i))))
            {
                miXML.Root.Add(el);
            }
            using (var con = new SqlConnection("Server=localhost;Database=HT;Trusted_Connection=True;"))
            {
                con.Open();
                using (var cmd = new SqlCommand("uspUpsert", con) {CommandType = CommandType.StoredProcedure})
                {
                    cmd.Parameters.AddWithValue("@X", miXML.ToString());
                    cmd.Parameters.AddWithValue("@fileName", fname);
                    cmd.ExecuteNonQuery();
                }
            }
