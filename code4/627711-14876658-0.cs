     public class MyClass:IDisposable
    {
        SqlConnection myCon;
        public MyClass() 
        {
            myCon = new SqlConnection(connectionString);
        }
        public DataTable GetList()
        {
            // use global connection
        }
        public void Insert()
        {
            // use global connection
        }
        public void Dispose()
        {
            myCon.Close();
        }
    }
