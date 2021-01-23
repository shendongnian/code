        var insertPassed = false;
        SqlCommand sqlcmd = new SqlCommand();
        var ErrorMsg = string.Empty;
        using (SqlConnection sqlConn = new SqlConnection(connString))
        {
            sqlConn.Open();
            sqlcmd.Connection = sqlConn;
            SqlTransaction transaction;
            transaction = sqlConn.BeginTransaction("EmergencyContact");
            sqlcmd.CommandTimeout = 60;
            sqlcmd.Transaction = transaction;
            sqlcmd.CommandText = "InsertEmergencyContact";
            sqlcmd.CommandType = CommandType.StoredProcedure;
            //get and assign all the SQL Params from the dictionary object
            sqlcmd.Parameters.AddWithValue("@StudentId", StudId);//int value
            sqlcmd.Parameters.AddWithValue("@StudentFName", StudFName);
            sqlcmd.Parameters.AddWithValue("@StudentLName", StudLName);
            sqlcmd.Parameters.AddWithValue("@TransferAnotherSchool", TransAnotherSchool);
            sqlcmd.Parameters.AddWithValue("@LastSchoolAttended", LastSchoolAttend ?? (object)DBNull.Value);
            sqlcmd.Parameters.AddWithValue("@Grade", Grade ?? (object)DBNull.Value);
            sqlcmd.Parameters.AddWithValue("@District", District ?? (object)DBNull.Value);
            sqlcmd.Parameters.AddWithValue("@SchoolAddr", SchoolAddr ?? (object)DBNull.Value);
            sqlcmd.Parameters.AddWithValue("@City", City ?? (object)DBNull.Value);
            sqlcmd.Parameters.AddWithValue("@State", State ?? (object)DBNull.Value);
            sqlcmd.Parameters.AddWithValue("@Zip", zip ?? (object)DBNull.Value);
            try
            {
                sqlcmd.ExecuteNonQuery();
                sqlcmd.Transaction.Commit();
                insertPassed = true;
            }
            catch (SqlException sqlex)
            {
                ErrorMsg = sqlex.Message;
                insertPassed = false;
                try
                {
                    transaction.Rollback("EmergencyContact");
                }
                catch (Exception ex)
                {
                    ErrorMsg = ex.Message;
                }
            }
            ((IDisposable)sqlcmd).Dispose();
            if (transaction != null) transaction = null;
        }
    
        return insertPassed;
    }
