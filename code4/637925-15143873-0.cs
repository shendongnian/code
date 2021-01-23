    public void Cancel()
    {
        foreach(var customer in _response.CustomersList)
        {
            _request2 = new CancelCust();
            _request2.CommandUser = _request.CommandUser;      
            _request2.CustID = customer.CustID;         
            _request2.Company = _request.Company;      
        }
    } 
