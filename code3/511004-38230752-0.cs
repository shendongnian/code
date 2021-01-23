    /// <summary>
    /// Custom implementation of a wrapper to <see cref="DbConnection"/>.
    /// Allows custom behavior at the connection level.
    /// </summary>
    internal class CustomDbConnection : DbConnectionWrapper
    {
        /// <summary>
        /// Opens a database connection with the settings specified by 
        /// the <see cref="P:System.Data.Common.DbConnection.ConnectionString"/>.
        /// </summary>
        public override void Open()
        {
            base.Open();
    
            //After the connection has been opened, use this spot to do any initialization type logic on/with the connection
    
        }
    
        /// <summary>
        /// Closes the connection to the database. This is the preferred method of closing any open connection.
        /// </summary>
        /// <exception cref="T:System.Data.Common.DbException">
        /// The connection-level error that occurred while opening the connection.
        /// </exception>
        public override void Close()
        {
            //Before closing, we do some cleanup with the connection to make sure we leave it clean
            //   for the next person that might get it....
    
            CleanupConnection();
    
            base.Close();
        }
    
        /// <summary>
        /// Cleans up the connection so the next person that gets it doesn't inherit our junk.
        /// </summary>
        private void CleanupConnection()
        {
            //Create the ADO.NET command that will call our stored procedure
            var cmd = CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "p_cleanup_connection";
    
            //Run the SP
            cmd.ExecuteNonQuery();
        }
    }
