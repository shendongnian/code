    public static class StorageExtensions
    {
        public static bool SafeCreateIfNotExists(this CloudTable table, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            do
            {
                try
                {
                    return table.CreateIfNotExists(requestOptions, operationContext);
                }
                catch (StorageException e)
                {
                    if ((e.RequestInformation.HttpStatusCode == 409) && (e.RequestInformation.ExtendedErrorInformation.ErrorCode.Equals(TableErrorCodeStrings.TableBeingDeleted)))
                        Thread.Sleep(1000);// The table is currently being deleted. Try again until it works.
                    else
                        throw;
                }
            } while (true);
        }
    }
