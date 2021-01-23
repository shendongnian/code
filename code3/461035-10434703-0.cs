    class Page
    {
        IQueryable<Page> ChildPages;
        string type; //catalog or product
        // the query
        static IQueryable<Page> GetProductsWithCatalogAncestor(IQueryable<Page> pages)
        {
            return FixPoint<bool, IQueryable<Page>, IQueryable<Page>>
                (processChildPages => (hasCatalogAncestor, thePages) 
                    => thePages.SelectMany(p => (hasCatalogAncestor && p.type == "product" ) 
                        ? new[] { p }.AsQueryable()
                        : processChildPages(hasCatalogAncestor || p.type == "catalog", p.ChildPages)))
                        (false, pages);
        }
        // Generic FixPoint operator
        static Func<T1, T2, TResult> FixPoint<T1, T2, TResult>(Func<Func<T1, T2, TResult>, Func<T1, T2, TResult>> f)
        {
            return (t1, t2) => f(FixPoint(f))(t1, t2);
        }
    }
