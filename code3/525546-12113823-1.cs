    public static class RetrieveExtension
    {
        public static bool? NullSafe_IsForm(this Retrieve retrieved)
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
