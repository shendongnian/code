    private static void CallProc(string storedProcName, Action<SqlCommand> fillParams, Action postAction, Action onError)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(String.Format("[dbo].[{0}]", storedProcName), connection))
            {
                try 
                {
                    if(fillParams != null)
                        fillParams(command);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    if(postAction != null)
                        postAction();
                 }        
                catch (InvalidOperationException)
                {
                    //log and/or rethrow or ignore
                    throw;
                }
                catch (SqlException)
                {
                    //log and/or rethrow or ignore
                    throw;
                }
                catch (ArgumentException)
                {
                    //log and/or rethrow or ignore
                    throw;
                }
                catch
                {
                    if(onError != null)
                       onError();
                }
            }
        }
    }
