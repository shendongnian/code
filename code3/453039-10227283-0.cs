        public class Customer
        {
            protected List<CustomerAddress> _customerAddresList 
               = new List<CustomerAddress>();
        }
        public class Worker : Customer
        {
            
        }
        public class CustomerAddress
        {
            protected string _Address1;
            public virtual string Address1
            {
                get { return "customer address: " + _Address1; }
                set { _Address1 = value; }
            }
        }
        public class WorkerAddress: CustomerAddress
        {
            public override string Address1
            {
                get { return "Worker Address: " + _Address1; }
            }
        }
