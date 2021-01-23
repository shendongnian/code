    IQueryable<MyDataTable> GetData(bool sortByDate)
    {
        var result = from x in DataContext.Table<MyDataTable>
                     where SomeMatchingClause(x)
                     select x;
        
        if(sortByDate)
        {
            result = result.OrderBy(x => x.Date); // or OrderByDescending
        }
        
        return result;
    }
