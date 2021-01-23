            bool bStatus = false;
            string[] lines = commands; // regex.Split(sql);
            SqlTransaction transaction = null;
            if (useTransaction)
                transaction = connection.BeginTransaction();
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.Connection = connection;
                if (useTransaction)
                    cmd.Transaction = transaction;
                foreach (string line in lines)
                {
                    if (line.Length > 0)
                    {
                        cmd.CommandText = line;
                        cmd.CommandType = CommandType.Text;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            string msg = e.Message;
                            if (useTransaction)
                                transaction.Rollback();
                            throw;
                        }
                    }
                }
                bStatus = true;
            }
            if (bStatus && useTransaction)
                transaction.Commit();
            return bStatus;
        }
