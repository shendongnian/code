    // Query that calls the OrderTotal function to recalculate the order total.
    string queryString = @"USING Microsoft.Samples.Entity;
        FUNCTION OrderTotal(o SalesOrderHeader) AS
        (o.SubTotal + o.TaxAmt + o.Freight)
    
        SELECT [order].TotalDue AS currentTotal, OrderTotal([order]) AS calculated
        FROM AdventureWorksEntities.SalesOrderHeaders AS [order]
        WHERE [order].Contact.ContactID = @customer";
    
    int customerId = 364;
    
    
    using (AdventureWorksEntities context =
        new AdventureWorksEntities())
    {
        ObjectQuery<DbDataRecord> query = new ObjectQuery<DbDataRecord>(queryString, context);
        query.Parameters.Add(new ObjectParameter("customer",customerId));
    
        foreach (DbDataRecord rec in query)
        {
            Console.WriteLine("Order Total: Current - {0}, Calculated - {1}.", 
                rec[0], rec[1]);
        }
    }
