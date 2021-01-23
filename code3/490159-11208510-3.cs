    private void RemoveAllCategoriesFromOutlook()
    {
            var containsFiledNow = DoesCategoryNameExist(outlookApplication.Session.Categories, "Filed");
            var containsPendingNow = DoesCategoryNameExist(outlookApplication.Session.Categories, "Pending");
            if (!containsFiled && containsFiledNow) 
            {
                outlookApplication.Session.Categories.Remove("Filed");
                Trace.TraceInformation("Deleted Filed Category!")
            }
            if (!containsPending && containsPendingNow) 
            {
                outlookApplication.Session.Categories.Remove("Pending");
                Trace.TraceInformation("Deleted Pending Category!")
            }
    }
