    public  class CustomerHandler
    {
        // in BL you may have to call several DAL methods to perform one Task 
        // here i have added validation and insert 
        // in case of validation fail method return false
        public bool InsertCustomer(Customer customer)
        {
            if (CustomerDataAccess.Validate(customer))
            {
                CustomerDataAccess.insertCustomer(customer);
                return true;
            }
            return false;
        }
    }
