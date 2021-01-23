    public class MyClass
    {
         public void UnitTestOne(int i) { /* impl */ }
         public int UnitTestTwo() { /* impl */ }
         public void UnitTestThree()
         {
              var methodCallExpressions = new Expression<Action<MyClass>>[] { 
                  mc => mc.UnitTestOne(default(int)), //Note that a dummy argument is provided
                  mc => mc.UnitTestTwo() 
              };
              
              var names = methodCallExpressions.Select(mce => 
                  ((MethodCallExpression) mce.Body).Method.Name);
         }
    }
