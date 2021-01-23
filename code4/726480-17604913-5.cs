        var results = ctx.Statements // you are getting DbSet<Statement> that implements interface IQueryable<Statement> (and IQueryable<T> implements IEnumerable<T>)
                         .Include("StatementDetails") // still IQueryable<Statement>
                         .Include("StatementDetails.Entry") // still IQueryable<Statement>
                         .Where(filter) // Cuz your filter is Func<..> and there are no extension methods on IQueryable that accepts Func<...> as parameter, your IQueryable<Statement> casted automatically to IEnumerable<Statement>. Full collection will be loaded in your memory and only then filtered. That's bad
                         .Take(100) // IEnumerable<Statement>
        .Select(s => new StatementSearchResultDTO { .... // IEnumerable<Statement> -> IEnumerable<StatementSearchResultDTO>
        }
