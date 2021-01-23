        // Inheriting BL
        public class CustomerBL2 : Customer
        {
            public virtual void AddAdress(CustomerAddress address)
            {
                _customerAddresList.Add(address);
            }
        }
        public class WorkerBL2 : CustomerBL2
        {
            public override void AddAdress(CustomerAddress address)
            {
                if (!(address is WorkerAddress))
                    throw new Exception();
                base.AddAdress(address);
            }
        }
