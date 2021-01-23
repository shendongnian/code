    oleCommand.Parameters.Add(new OleDbParameter("@LastName", OleDbType.VarChar, 20, 
                                                 ParameterDirection.Input, false, 10, 
                                                 0, "LastName", 
                                                 DataRowVersion.Original, null)
                             ).Value = String.IsNullOrEmpty(last) ? DBNull.Value : last;
