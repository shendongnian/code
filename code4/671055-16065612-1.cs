    public class SourceService : ServiceStack.ServiceInterface.Service
    {
        public SqlCeFactory DbFactory { get; set; }
        public object Get(SomeRequest request)
        {
            using (var con = DbFactory.OpenConnection())
            {
                //use SqlCeConnection()
            }
            //more code
        }
    }
