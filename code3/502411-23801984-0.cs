     using (SqlConnection connection = new SqlConnection())
            {
                string connectionStringName = this.DataWorkspace.dbsMSccData.Details.Name;
                connection.ConnectionString =
                ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                string procedure = entity.Procedure;
                using (SqlCommand command = new SqlCommand(procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    //foreach (var item in entity.StoredProcedureParameters)
                    //{
                    //    command.Parameters.Add(
                    //        new SqlParameter(item.ParameterName, item.ParameterValue));
                    //}
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            this.Details.DiscardChanges();
