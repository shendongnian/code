    public class DataHolder
    {
        private DataSet m_dataSet;
        private static DataHolder m_instance;
    
        private DataHolder()
        {
            m_dataSet = ... // Fill/Create it here
        }
        public static DataHolder Instance
        {
            get
            {
                if (m_instance = null)
                    m_instance = new DataHolder();
                return m_instance;
            }
        }
        public DataSet Data
        {
            get { return m_dataSet; }
        }
    }
