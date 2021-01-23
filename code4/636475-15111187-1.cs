    class WithCustomerType {
        private int custType;
        public string CustomerType {
            get {
                ... // Custom logic goes here
            }
        }
    }
    public class CustomerDTO : WithCustomerType {
        ...
    }
