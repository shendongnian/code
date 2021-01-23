    public class DataAcessor
    {
        private _connectionString;
        public DataAcessor(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool ValidateUser(string username, string password)
        {
            //code to call database for validation only, returns true or false
        }
        public string GetUserName(int userID) //or some other call to the database
        { }
    }
