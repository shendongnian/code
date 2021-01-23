    public Category FindCategory(Category category, string url)
    {
        if(category.Url == url)
        {
            return category;
        }
    
        Category solution = null;    
    
        foreach(Category child in category.Children)
        {
            solution = FindCategory(child, url);
            if(solution != null)
            {
                return solution;
            }
        }
        
        return null;
    }
