    public class EntityFunctionsExpressions : IEntityFunctionsExpressions
    {
        public EntityFunctionsExpressions()
        {
        }
    
        public IQuerable<myType> GetSelectQuery(IQuerable<EcaseReferralCase> query)
        {
            // Expression for LINQ to Entities, does not work with LINQ to Objects
            return 
                        (myType)(from o in query
                        select new myType
                        {
                            // LINQ to Entity
                            myValue = (DateTime)System.Data.Objects.EntityFunctions.AddDays(o.StartDate, 0),
                            newValue = (DateTime)System.Data.Objects.EntityFunctions.AddDays(o.StartDate, 30)
    
                        });
        }
    }
