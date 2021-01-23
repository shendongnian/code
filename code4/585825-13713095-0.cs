    class MyDb
    {
        public MyDb()
        {
        }
    
        public void Initialize()
        {
            // open the connection
        }
    
        public void Finalize()
        {
            // close the connection
        }
    
        public List<object[]> Query(string command, List<SqlParameter> params)
        {
            // prepare command
            // execute reader
            // read all values into List of object[], and return it
        }
    }
