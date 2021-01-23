    public class DynTestProxy:IDynTest
    {
        public dynamic GetData()
        {
            return (dynamic) new { DynamicProperty = "From Unit Test" };
        }
    }
