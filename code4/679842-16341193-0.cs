      CepContext context = new CepContext();
            JsonResult result = Json(new { Street = "", District = "", City = "", UF = "" });
            using (var cmd = context.Database.Connection.CreateCommand())
            {
                cmd.CommandText = "spLogradouro @pCEP, @pUF, @pLOCALIDADE, @pTIPOLOGRADOURO, @pLOGRADOURO";
                cmd.Parameters.Add(new SqlParameter("pCEP", filter));
                cmd.Parameters.Add(new SqlParameter("pUF", ""));
                cmd.Parameters.Add(new SqlParameter("pLOCALIDADE", ""));
                cmd.Parameters.Add(new SqlParameter("pTIPOLOGRADOURO", ""));
                cmd.Parameters.Add(new SqlParameter("pLOGRADOURO", ""));
                cmd.Connection.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    result = Json(new
                    {
                        Street = reader.GetString(reader.GetOrdinal("log_logradouro")),
                        District = reader.GetString(reader.GetOrdinal("log_bairro")),
                        City = reader.GetString(reader.GetOrdinal("log_localidade")),
                        UF = reader.GetString(reader.GetOrdinal("log_uf"))
                    });
                }
                cmd.Connection.Close();
            }
