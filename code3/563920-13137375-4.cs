    public class WhereClause<T>
    {
        private readonly Func<T, string> _selector;
        public Func<T, string> Selector { get { return _selector; } }
        private readonly string _value;
        public string Value { get { return _value; } }
        public WhereClause(Func<T, string> selector, string value)
        {
            this._selector = selector;
            this._value = value;
        }
        /// <summary>
        /// Append the where clause to the given query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<T> AppendTo(IEnumerable<T> query)
        {
            return query.Where(c => this.Selector.Invoke(c) == this.Value);
        }
        /// <summary>
        /// Append the wheres clauses to the given query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IEnumerable<T> AppendTo(IEnumerable<T> query, IEnumerable<WhereClause<T>> wheres)
        {
            var filteredQuery = query;
            foreach (var where in wheres)
            {
                filteredQuery = where.AppendTo(filteredQuery);
            }
            return filteredQuery;
        }
    }
    [TestClass]
    public class WhereClauseTests
    {
        public class Customer { public string FirstName; public string LastName;}
        [TestMethod()]
        public void WhereClauseTest()
        {
            var jonSkeet = new Customer() { FirstName = "Jon", LastName = "Skeet" };
            var joelOnSoftware = new Customer() { FirstName = "Joel", LastName = "OnSoftware" };
            var customers = new List<Customer>() { jonSkeet, joelOnSoftware };
            var jonSkeetWheres = new List<WhereClause<Customer>>() { 
                new WhereClause<Customer>(c => c.LastName, "Skeet"),
                new WhereClause<Customer>(c => c.FirstName,  "Jon" )
            };
            var query = WhereClause<Customer>.AppendTo(customers, jonSkeetWheres);
            var result = query.ToList();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(jonSkeet, result.Single());
        }
    }
