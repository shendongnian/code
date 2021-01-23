        // Inheriting instances
        public class CustomerBL : Customer
        {
            public void AddAdress(CustomerAddress address)
            {
                _customerAddresList.Add(address);
            }
        }
        public class WorkerBL: Worker
        {
            // Not inehritable, different signature
            public void AddAdress(WorkerAddress address)
            {
                _customerAddresList.Add(address);
            }
        }
