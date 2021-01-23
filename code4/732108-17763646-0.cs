        #region CODTEC SISTEMAS
        /// <summary>
        /// Return a typed list of objects, reader is closed after the call
        /// </summary>
        public static DataTable Query(this IDbConnection cnn, string sql, object param, IDbTransaction transaction, int? commandTimeout, CommandType? commandType)
        {
            var identity = new Identity(sql, commandType, cnn, typeof(DapperRow), param == null ? null : param.GetType(), null);
            var info = GetCacheInfo(identity);
            IDbCommand cmd = null;
            IDataReader reader = null;
            bool wasClosed = cnn.State == ConnectionState.Closed;
            try
            {
                cmd = SetupCommand(cnn, transaction, sql, info.ParamReader, param, commandTimeout, commandType);
                if (wasClosed) cnn.Open();
                reader = cmd.ExecuteReader(wasClosed ? CommandBehavior.CloseConnection : CommandBehavior.Default);
                wasClosed = false; // *if* the connection was closed and we got this far, then we now have a reader
                // with the CloseConnection flag, so the reader will deal with the connection; we
                // still need something in the "finally" to ensure that broken SQL still results
                // in the connection closing itself
                DataTable dt = new DataTable();
                dt.Load(reader);
                
                // happy path; close the reader cleanly - no
                // need for "Cancel" etc
                reader.Dispose();
                reader = null;
                return dt;
            }
            finally
            {
                if (reader != null)
                {
                    if (!reader.IsClosed) try { cmd.Cancel(); }
                        catch { /* don't spoil the existing exception */ }
                    reader.Dispose();
                }
                if (wasClosed) cnn.Close();
                if (cmd != null) cmd.Dispose();
            }
        }
        #endregion
