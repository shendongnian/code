    public class Customer
    {    
        public Customer()
        {
            InstanceCount++;
        }
    
        public int InstanceCount { get; private set; } //Count should be increased by the clients of this class rather should be increased in the constructor only
    }
