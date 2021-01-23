    static readonly Func<AdventureWorksEntities, Decimal, IQueryable<SalesOrderHeader>> s_compiledQuery2 = 
        CompiledQuery.Compile<AdventureWorksEntities, Decimal, IQueryable<SalesOrderHeader>>(
                (ctx, total) => from order in ctx.SalesOrderHeaders
                                where order.TotalDue >= total
                                select order);
    
    static void CompiledQuery2()
    {            
        using (AdventureWorksEntities context = new AdventureWorksEntities())
        {
            Decimal totalDue = 200.00M;
    
            IQueryable<SalesOrderHeader> orders = s_compiledQuery2.Invoke(context, totalDue);
    
            foreach (SalesOrderHeader order in orders)
            {
                Console.WriteLine("ID: {0}  Order date: {1} Total due: {2}",
                    order.SalesOrderID,
                    order.OrderDate,
                    order.TotalDue);
            }
        }            
    }
