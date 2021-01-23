    private List<SubCategory> _subCategories = new List<SubCategory>();
    private class Category
    {
        int numberOfCategories = 0;
    
        Category(int categoryNumber)
        {
            numberOfCategories = categoryNumber;
    
            for (int i = 0; i <= numberOfCategories; ++i)
            {
               _subCategories.Add(new SubCategory());   
            }
        }
    }
