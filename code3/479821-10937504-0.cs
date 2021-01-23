    public abstract class DataService
    {
        protected object myWidget = new Widget();
        public object SomeDataBaseCall(string storedProcedure)
        {
            DoSomeCustomThing();
            //do db stuff
            object SomeReturnObjValue = db.ExecuteScalar(storedProcedure);
            return SomeReturnObjValue;
        }
        protected void DoSomeCustomThing() {}
    }
    public class Customer : DataService
    {
        override protected void DoSomeCustomThing()
        {
            // do your custom thing here
        }
    }
