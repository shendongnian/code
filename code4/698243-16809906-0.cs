    public class DataSet
    {
        private DataSet()
        {
        }
        public DataSet _instance = null;
        public static DataSet Instance
        {
           get{ if (_instance = null){_instance = new DataSet();}return _instance;}
        }
        private IDictionary<string, MyClass1> _property1 = null;
        public IDictionary<string, MyClass1> Property1
        {
            get
            {
               result = _property;
               if (result == null)
               {
                 //read database
               } 
               return result;
            }
        }
        
        
