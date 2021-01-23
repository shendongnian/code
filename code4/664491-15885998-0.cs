    public class PaymentHandler {
        
        private customerRepository;
    
        public PaymentHandler(CustomerRepository customerRepository) {
            this.customerRepository = customerRepository;
        }
        public void handlePayment(CustomerId customerId, Money amount) {
            Customer customer = customerRepository.findById(customerId);
            customer.charge(amount);
        }
    }
    public interface CustomerRepository {
        public Customer findById(CustomerId customerId);
    }
    public class DefaultCustomerRepository implements CustomerRepository {
    
        private Database database;    
    
        public CustomerRepository(Database database) {
            this.database = database;
        }
    
        public Customer findById(CustomerId customerId) {
            Result result = database.executeQuery(...);
            // do some logic here
            return customer;
        }
    }
    public interface Database {
        public Result executeQuery(Query query);
    }
