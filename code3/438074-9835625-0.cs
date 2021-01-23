    public class Singleton123
    {
        private static readonly string _property1 = ClassLoadData.LoadData();
        
        public static string MyProperty1
        {
            get
            {
                return _property1;
            }
        }
        
    }
    public class ClassLoadData
    {
        public static string LoadData()
        {
            // any logic to load data
            return "test";
        }
    }
