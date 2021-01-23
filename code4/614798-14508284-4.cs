    public class CustomerViewModel
    {
        // This is the same as CustomerModel.CustomerName, but the names differ
        public CustomerModel CustomerModel { get; set; }
         
        pubiic CustomerViewModel()
        {
            CustomerModel = new CustomerModel();
        }
    }
    public class CustomerModel
    {
         public string CustomerName { get; set; }
         public int ID { get; set; }
    }
