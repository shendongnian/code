    public class MockEntityFunctionsExpressions : IEntityFunctionsExpressions
    {
        public MockEntityFunctionsExpressions()
        {
        }
    
        public IQuerable<myType> GetSelectQuery(IQuerable<EcaseReferralCase> query)
        {
            // Expression for LINQ to Objects, does not work with LINQ to Entities
            return 
                        (myType)(from o in query
                        select new myType
                        {
                            // LINQ to Object
                            myValue = o.StartDate.AddDays(0),
                            newValue = o.StartDate.AddDays(30)
                        });
        }
    }
