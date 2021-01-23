    for(int i=0; i < Model.Categories.OrderBy(i => i.CategoryName).Count/2; i++)
    {
        // do stuff
    }
    for(int i=Model.Categories.OrderBy(i => i.CategoryName).Count/2; i < Model.Categories.OrderBy(i => i.CategoryName).Count; i++)
    {
        // do different stuff
    }
