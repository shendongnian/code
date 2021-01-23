    public static class RetrieveExtension
    {
        public static bool NullSafeIsForm(this Retrieve retrieved)
        {
            if(retrieved == null)
            {
                return false;
            }
            else
            {
                return retrieved.IsForm;
            }
        }
    }
