                 SqlConnection conn = null;
                 SqlDataReader rdr  = null;
                 conn = new 
                    SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI");
                conn.Open();
    
                // 1.  create a command object identifying
                //     the stored procedure
                SqlCommand cmd  = new SqlCommand(
                    "Stored_PROCEDURE_NAME", conn);
    
                // 2. set the command object so it knows
                //    to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
    
                // 3. add parameter to command, which
                //    will be passed to the stored procedure
                cmd.Parameters.Add(
                    new SqlParameter("@PARAMETER_NAME", PARAMETER_VALUE));
    
                // execute the command
                rdr = cmd.ExecuteReader();
    
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    var result = rdr["COLUMN_NAME"].ToString();
                }
