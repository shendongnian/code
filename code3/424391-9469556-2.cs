        public static int CountByFilters(this IEnumerable<P> ProgramList, Expression<Func<P, IEnumerable<IFilter>>> exp, int[] ids)
        {
            var c = exp.Compile();
            HashSet<int> i = new HashSet<int>(ids);
            
            return (from x in ProgramList
                    let filters = c.Invoke(x).Select(f => f.ID)
                    where i.IsSubsetOf(filters)
                    select x).Count();
            
        }
