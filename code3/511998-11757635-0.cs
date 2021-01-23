    //DAL
    public class DataAccess
    {
        public static void GetCustomerByNumber(int number)
        {
            var objCustomer = dbContext.Customers.Where(c => c.CustCode == number).First();
            return objCustomer;
        }
    }
    //Models
    public class Customer
    {
        public string Name { get; set; }
        public int Number { get; set; }
    
        public Customer GetCustomerByNumber(int number) 
        {
           return DataAccess.GetCustomerByNumber(number);
        }
    
        public void ChangeProfile(ProfileInfo profile)
        {
           //...
        }
    }
