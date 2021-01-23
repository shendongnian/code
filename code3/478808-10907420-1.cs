    public class MyDataSource
    {
        private static IEnumerable<Table2> myData;
        public MyDataSource(IEnumerable<Table2> data)
        {
            myData = data;
        }
        public static IEnumerable<Table2> GetMyData()
        {
            return myData;
        }
    }
