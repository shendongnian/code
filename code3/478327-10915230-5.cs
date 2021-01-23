    public class DynTestProxy:IDynTest
    {
        public dynamic GetData()
        {
            dynamic r = new ExpandoObject();
            r.DynamicProperty = "From Unit Test";
            return r;
        }
    }
