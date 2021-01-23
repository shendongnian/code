    public class MySqlClass : IDisposable
    {
        private SqlCommand cmd { get; set; }
        public MySqlClass() { }
    
        public void DoSomething1(string myParams)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //use cmd here...
            }
        }
        public void DoSomething1(string myParams)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //use cmd here...
            }
        }
        //DISPOSE STUFF HERE    
    }
    
