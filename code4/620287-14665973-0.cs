    var categories = new int[] { 14, 99, 4428 };
    var companies = context.Companies
                           .Where(c => c.Name.Contains(freeTextFilter))
                           .OrderBy(c = categories.Contains(c.CategoryId) 
                                            ? c.CategoryId 
                                            : int.MaxValue)
                           .ThenBy(c => c.Name);
