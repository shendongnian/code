    string connectionString = "your connection string";
        using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("USP_VISUALIZAR_PIS_PROCESSO_IMPORTACAO_DETALHE_HISTORICO", connection))
                {
                    command.CommandTimeout = 0;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter p1 = command.Parameters.Add("@DATA_HISTORICO", SqlDbType.DateTime);
                    p1.Direction = ParameterDirection.Input;
                    p1.Value = dataHistorico;
                    SqlParameter p2 = command.Parameters.Add("@SIGLA_ESTADO", SqlDbType.VarChar);
                    p2.Direction = ParameterDirection.Input;
                    p2.Value = filtro.SiglaEstado;
                    //.... continue for rest of parameters
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                                
                            //Read your values into some data structure
                        }
                    }
                }
            }
