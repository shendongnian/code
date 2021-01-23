    [SetUp]
    public void Setup()
    {
        containsFiled = DoesCategoryNameExist(outlookApplication.Session.Categories, "Filed") || IsCategoryColorAlreadyUsed(categories, FiledCategoryColor);
        containsPending = DoesCategoryNameExist(outlookApplication.Session.Categories, "Pending") || IsCategoryColorAlreadyUsed(categories, PendingCategoryColor);
    }
