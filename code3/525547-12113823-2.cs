    public static class RetrieveExtension
    {
        public static bool? Nullable_IsForm(this Retrieve retrieved)
        {
            if(retrieved == null)
            {
                return null;
            }
            else
            {
                return retrieved.IsForm;
            }
        }
    }
