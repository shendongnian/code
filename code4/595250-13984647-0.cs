    [DataContract]
    public class Customer
    {
        [DataMember]
        public int CustomerID{ get; set; }    }
        [DataMember]
        public string CustomerName{ get; set; }    
    }
    public interface ICustomerService
    {
       [OperationContract]
       List<Customer> GetAllCustomer();
    }
    public class CustomerService:ICustomerService
    {
       List<Customer> GetAllCustomer()
       {
           List<Customer> customers = new List<Customer>();
           using(SqlConnection con = new SqlConnection("Database Connection String"))
           {
            con.Open();     
            using(SqlCommand cmd = new SqlCommand("Select * from Customer",con))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                 Customer customer = new Customer();
                    customers.Add(customer);
                }
            }
           }
        return customers;
      }
    }
