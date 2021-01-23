    public class DBColumnReference : Attribute
    {
        string m_column;
        public string ColumnName
        {
            get { return m_column; }
        }
        public DBColumnReference(string column)
        {
            m_column = column;
        }
    }
    public class TestingObject4
    {
        string m_table = "TESTING_CORE_OBJECT4";
        public string Table
        {
            get { return m_table; }
        }
        private int m_id = 0;
        [DBColumnReference("an integer id")]
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }
    }
    class Program
    {
        private static Dictionary<string, PropertyInfo> FilterProperties(Type type)
        {
            Dictionary<string, PropertyInfo> result = new Dictionary<string, PropertyInfo>();
            if (type == null)
                return result;
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                // Attribute[] atributes = Attribute.GetCustomAttributes(prop,   true);
                object[] atributes = prop.GetCustomAttributes(typeof(DBColumnReference), true);
                if (atributes != null && atributes.Length != 0)
                {
                    DBColumnReference reference = atributes[0] as DBColumnReference;
                    result.Add(reference.ColumnName, prop);
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Dictionary<string, PropertyInfo> resultCollection = FilterProperties(typeof(TestingObject4));
            foreach (var singleObject in resultCollection)
            {
                Console.WriteLine(singleObject.Key + "  " + singleObject.Value);
            }
            Console.ReadKey(false);
        }
    }
