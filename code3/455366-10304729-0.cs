        var query = from c in this.ObjectContext.CallLogs                        
                    select new
                    {
                        CallDescription = c.CallDescription,
                        CustomerID = c.CustomerID.HasValue ? c.CustomerID.Value : 0,
                        CustomerName = c.CustomerID.HasValue ? c.Customer.Name : ""
                    };
        if (maximumRows > 0)
            query = query.Skip(startRowIndex).Take(maximumRows);
        return query.ToList<object>();
