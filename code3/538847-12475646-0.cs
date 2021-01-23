    public interface ICustomer{
        ICustomerData GetCustomerData(int index);
    }
    public interface ICustomerData{
        int CustomerId{ get; }
    }
    public class OnlineCustomer : ICustomer{
        private MSSQLDataSet.Customer innerCustomer;
        public OnlineCustomer(MSSQLDataSet.Customer innerCustomer){
            this.innerCustomer = innerCustomer;
        }
        ICustomerData GetCustomerData(int index){
            return new OnlineCustomerData(innerCustomer[index]);
        }
    }
    public class OnlineCustomerData : ICustomerData{
        private MSSQLDataSet.CustomerDataTable innerCustomer;
        public OnlineCustomerData(MSSQLDataSet.CustomerDataTable innerCustomer){
            this.innerCustomer = innerCustomer;
        }
        
        public int CustomerId{
            get {
                return innerCustomer.CustomerId;
            }
        }
    }
    public class OfflineCustomerData : ICustomerData{
        private CompactSQLDataSet.CustomerDataTable innerCustomer;
        public OfflineCustomerData(CompactSQLDataSet.CustomerDataTable innerCustomer){
            this.innerCustomer = innerCustomer;
        }
        
        public int CustomerId{
            get {
                return innerCustomer.CustomerId;
            }
        }
    }
    public class OfflineCustomer : ICustomer{
        private CompactSQLDataSet.Customer innerCustomer;
        public OfflineCustomer(CompactSQLDataSet.Customer innerCustomer){
            this.innerCustomer = innerCustomer;
        }
        ICustomerData GetCustomerData(int index){
            return new OfflineCustomerData(innerCustomer[index]);
        }
    }
    public class Program{
        private ICustomer customer;
        public  ICustomer Customer{
            get{
                if(customer == null)
                    customer = CreateCustomer();
                retrun customer;
            }
        }
    
        public ICustomerData CreateCustomer(){
            if(online){
                new OnlineCustomer(new MSSQLDataSet.Customer);
            } else {
               new OfflineCustomer(new CompactSQLDataSet.Customer);
            }
        }
        public void Usage(){
            ICustomerData data12 = Customer.GetCustomerData(12);
            int id = data12.CustomerId;
        }
    }
