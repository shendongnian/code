    public interface IWcfCustomerService
    {
        Customer GetCustomerById(int id);
        List<Customer> GetCustomerByIds(int[] id);
        Customer GetCustomerByUserName(string userName);
        List<Customer> GetCustomerByUserNames(string[] userNames);
        Customer GetCustomerByEmail(string email);
        List<Customer> GetCustomerByEmails(string[] emails);
    }
