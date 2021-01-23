    namespace Microsoft.Data.Schema.UnitTesting.Conditions
    {
         public abstract class ResultSetCondition : TestCondition
         {
              //...      
              internal abstract void DoAssert(DataTable resultSet);
         }
    }
