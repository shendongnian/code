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
                            assertMethod = (vals) =>Assert.AreEqual(vals[0],vals[1]);
                            propertyExpressions = null
                        };
       var asser2 = new Assertion()
                        {
                            assertMethod = (vals)=>Assert.AreEqual((string)vals[0],(string)vals[1],(bool)vals[2]);
                            propertyExpressions = null
                        };
        asser.assertMethod(1, 1);//calling object,object overload
        asser2.assertMethod("ab", "cd", true);//calling string,string,bool overload
    }
