    public class Customer : IDataAccessObject
    {
        public Customer()
        {
            _dataAccess = new DataAccess();
        }
    
        public string CustomerDoSomething(string SomeDataEtc)
        {
            object ReturningObj = _dataAccess.SomeDBcall("my stored procedure");
            return ReturningObj.ToString();
        }
    }
