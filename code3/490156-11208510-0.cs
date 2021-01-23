    private void RemoveAllCategoriesFromOutlook()
    {
        while (DoesCategoryNameExist(outlookApplication.Session.Categories, "Filed"))
          outlookApplication.Session.Categories.Remove("Filed");
        while (DoesCategoryNameExist(outlookApplication.Session.Categories, "Pending"))
          outlookApplication.Session.Categories.Remove("Pending");
    }
