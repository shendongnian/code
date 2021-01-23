    public class MyController : Controller
    {
        private readonly ICustomerDL _customerDL;
        public MyController(ICustomerDL customerDL)
        {
            _customerDL = customerDL;
        }
    
        //Load your implementation into the controller through the constructor
        public MyController() : this(new CustomerDL()) {}
    
        ActionResult Save(CustomerModel cm)
        {
           if(!ValidateCustomerModel(cm))
           {
                //Deal with invalid data
           }
        
           _customerDL.UpdateCustomer(cm);
        
           //continue
        }
        
        public bool ValidateCustomerModel(CustomerModel model)
        {
            //Do stuff
            return true;
        }
    }
    
    public interface ICustomerDL
    {
        void UpdateCustomer(CustomerModel model);
    }
    
    public class CustomerDL : ICustomerDL
    {
        public void UpdateCustomer(CustomerModel model)
        {
           Customer c = new Customer();
           c.Id = cm.Id;
           c.Email = cm.Email;
        
           context.Entry<Customer>(c).State = System.Data.EntityState.Modified;
           context.SaveChanges();
        }
    }
