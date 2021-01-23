    ActionResult Save(CustomerModel cm)
    {
       if(!ValidateCustomerModel(cm))
       {
            //Deal with invalid data
       }
    
       UpdateCustomer(cm);
    
       //continue
    }
    
    public bool ValidateCustomerModel(CustomerModel model)
    {
        //Do stuff
        return true;
    }
    
    public void UpdateCustomer(CustomerModel model)
    {
       Customer c = new Customer();
       c.Id = cm.Id;
       c.Email = cm.Email;
    
       context.Entry<Customer>(c).State = System.Data.EntityState.Modified;
       context.SaveChanges();
    }
