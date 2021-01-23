        // Using generics
        public class Generic<TAddress>
        {
            private List<TAddress> _addresList
                = new List<TAddress>();
            protected virtual List<TAddress> AddresList
            {
                get { return _addresList; }
            }
        }
        public class CustomerG : Generic<CustomerAddress>
        {
        }
        public class WorkerG : Generic<WorkerAddress>
        {
        
        }
