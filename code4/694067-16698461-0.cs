    using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoreProcedure;
                    // here is good
                    cmd.Parameters.AddWithValue("@nombre", yourParamValue);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open(); 
                   
