            using (SqlConnection cnx = new SqlConnection(@"your connection string"))
            {
                cnx.Open();
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "SELECT [File] FROM [com].[catalog1] WHERE [FileName] = @filename";
                    cmd.Parameters.AddWithValue("filename", Request.QueryString["filename"]);
                    // sequential access is used for raw access
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        if (reader.Read())
                        {
                            // must be lower than 85K (to avoid Large Object Heap fragmentation)
                            byte[] chunk = new byte[0x10000]; 
                            long read;
                            long offset = 0;
                            do
                            {
                                read = reader.GetBytes(0, offset, chunk, 0, chunk.Length);
                                if (read > 0)
                                {
                                    Response.OutputStream.Write(chunk, 0, (int)read);
                                    offset += read;
                                }
                            }
                            while (read > 0);
                            Response.AddHeader("Content-Type", "application/pdf");
                            Response.AddHeader("Content-Disposition", "inline; filename=" + Request.QueryString["filename"] + ".pdf");                        
                        }
                    }
                }
            }
