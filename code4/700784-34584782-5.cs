    public class MyDataDAO
    {
        private static bool isDbInterceptionInitialised = false;
        public MyDataDAO()
        {
            if (!isDbInterceptionInitialised)
            {
                DbInterception.Add(new InsertUpdateInterceptor());
                isDbInterceptionInitialised = true;
            }
        }
        public void Insert(string dataToInsert)
        {
            using (myentities context = new myentities())
            {
                MyData myData = new MyData();
                myData.data = dataToInsert;
                // this will trigger the interceptor
                context.SaveChanges();
            }
        }
    }
    
