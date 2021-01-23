    public delegate void MyAction(params object[] args);
    public class Assertion
    {
        public List<PropertyExpression> propertyExpressions;
        public MyAction assertMethod;
    }
    public void Test()
    {
       var asser = new Assertion()
                        {
                            assertMethod = (vals) =>Assert.Equals(vals[0],vals[1]);
                            propertyExpressions = null
                        };
        asser.assertMethod(1, 1);
    }
