    public ICriteriaWrapper GetWithPagingSortingFiltering(
        Type entityType,
        string columnNames, 
        List<bool> searchableColumns, 
        string searchParameter,
        int numSortingColumns,
        List<int> sortingColumns,
        List<string> sortingDirection, 
        int currentPage,
        int itemsPerPage)
    {
        // Create the criteria for the given entity type
        var crit = _session.CreateCriteria(entityType);
    
        // Split the columns, which will be used as our properties
        var columns = columnNames.Split(',');
    
        // Add criteria for searchable columns, so long as a parameter is given
        if (searchParameter != string.Empty)
        {
            var disjunction = Restrictions.Disjunction();
    
            for (var i = 0; i < searchableColumns.Count; ++i)
            {
                if (searchableColumns[i])
                {
                    var column = columns[i];
                    var columnParts = column.Split('.');
    
                    // Handles immediate children only
                    if (columnParts.Count() == 2)
                    {
                        var child = columnParts[0];
                        var aliasName = "the" + child;
                        var propertyName = aliasName + "." + columnParts[1];
    
                        crit.CreateAlias(child, aliasName);
    
                        disjunction.Add(
                            Restrictions.Like(
                                Projections.Cast(NHibernateUtil.AnsiString, Projections.Property(propertyName)),
                                searchParameter, MatchMode.Start));
                    }
                    // Handles base level properties
                    else if (columnParts.Count() == 1)
                    {
                        disjunction.Add(
                            Restrictions.Like(
                                Projections.Cast(NHibernateUtil.AnsiString, Projections.Property(column)),
                                searchParameter, MatchMode.Start));
                    }
                    else
                    {
                        throw new Exception("Unrecognized number of children; add more conditionals!");
                    }
                }
            }
    
            crit.Add(disjunction);
        }
    
        // Grab the total items count
        var totalItemsCrit = CriteriaTransformer.Clone(crit);
        var totalItems = totalItemsCrit.SetProjection(Projections.RowCount()).UniqueResult();
    
        // Apply ordering
        for (var i = 0; i < numSortingColumns; ++i)
        {
            var direction = sortingDirection[i];
            var column = columns[sortingColumns[i]];
    
            if (direction == "asc")
                crit.AddOrder(Order.Asc(column));
            else if (direction == "desc")
                crit.AddOrder(Order.Desc(column));   
        }
    
        // Apply paging
        var startPage = (itemsPerPage == 0
                             ? 1
                             : currentPage/itemsPerPage + 1);
    
        crit.SetFirstResult(startPage).SetMaxResults(itemsPerPage);
    
        return new ICriteriaWrapper
            {
                Criteria = crit,
                TotalItems = Convert.ToInt32(totalItems)
            };
    }
