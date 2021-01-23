    Object customer = Hotel.Main.Manager.GetMainList(x);
    
    string result="";
    var custObj = customer as Customer;
    if (custObj !=null)
    {
        result = custObj.GetCustomerSpecificData();
    }
    
    var specialcustObj = customer as SpecialCustomer;
    if (specialcustObj !=null)
    {
       result = specialcustObj.GetCustomerSpecificData();
    }
    
    /* etc */
