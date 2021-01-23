    public class Customer
    {    
        public Customer()
        {
            InstanceCount++;
        }
    
        //Helps retrieving the total number of Customers
        public int InstanceCount { get; private set; } //Count should not be increased by the clients of this class rather should be increased in the constructor only
    }
