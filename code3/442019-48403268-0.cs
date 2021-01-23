        public static bool BlobExists(CloudBlobContainer container, string fileName)
        {
            var blob = container.GetBlobReference(fileName);
            try
            {
                blob.FetchAttributes();
                return true;
            }
            catch (StorageException e)
            {
                if (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.NotFound)
                {
                    return false;
                }
            }
            return false;
        }
