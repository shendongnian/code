    public sealed class CustomerProfitQuery : IResultTransformer
    {
        public static readonly string Sql = "SELECT Customer.Name, sum([Load].Profit) as Profit FROM Customer INNER JOIN [Load] ON Customer.Id = [Load].CustomerId GROUP BY Customer.Name";
        public static readonly CustomerProfitQuery Transformer = new CustomerProfitQuery();
        // make it singleton
        private CustomerProfitQuery()
        { }
        public IList TransformList(IList collection)
        {
            return collection;
        }
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            return new CustomerProfit
            {
                Name = (string)tuple[0],
                Profit = (decimal)tuple[1],
            };
        }
    }
    // usage
    var customerprofits = session.CreateSQLQuery(CustomerProfitQuery.Sql)
        .SetResultTransformer(CustomerProfitQuery.Transformer)
        .List<CustomerProfit>()
