    public class ConnectionClass
    {
        private static object lockobj = new object();
        public Result ExecuteQuery(Query query)
        {
            // wait until the resource is available
            lock (lockobj)
            {
                // open connection, get results
            }
        }
    }
