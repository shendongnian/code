        static void Main(string[] args)
        {
           var res = GetPageRows<Type1>(GetRowsAndFilter, t => true, null, 0, 0);
           var res2 = GetPageRows<Type2>(GetRowsAndFilter, t => true, null, 0, 0);
            Console.ReadLine();
        }
        public static List<T> GetPageRows<T>(Func<Expression<Func<T, bool>>, IEnumerable<T>> getRows, Expression<Func<T, bool>> predicate, List<int> sortOrder, int pageSize, int pageNo)
        {
            var filteredQueryable = getRows(predicate);
            return filteredQueryable.ToList();
        }
        private static IEnumerable<Type1> GetRowsAndFilter(Expression<Func<Type1, bool>> predicate)
        {
            return Enumerable.Empty<Type1>();
        }
        private static IEnumerable<Type2> GetRowsAndFilter(Expression<Func<Type2, bool>> predicate)
        {
            return Enumerable.Empty<Type2>();
        }
        private static IEnumerable<Type3> GetRowsAndFilter(Expression<Func<Type3, bool>> predicate)
        {
            return Enumerable.Empty<Type3>();
        }
