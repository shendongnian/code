    public ClayShannonDatabaseClass
    {
        private SqlCeConnection m_openConnection;
        public ClayShannonDatabaseClass()
        {
           m_openConnection = new SqlCeConnection();
           m_openConnection.Open();
        }
        public void Dispose()
        {
           m_openConnection.Close();
           m_openConnection.Dispose();
           m_openConnection = null;
        }
    }
