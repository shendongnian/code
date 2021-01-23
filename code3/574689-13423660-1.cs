    IQueryable<Category> temp = dataSource.GetCategories(T => T.IsActive);
    // Perform checks.
    if (!(temp != null)) throw new Exception();
    if (!temp.All(T => T.IsActive)) throw new Exception();
    // Return values.
    return temp;
