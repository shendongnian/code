    //Create your client details entity
    var details = new Clients_details
    {
        city = UICity.Text,
        first_name = UIFirst_name.Text,
        last_name = UIFamiliya.Text,
        name = UIName.Text    
    };
    
    //Create your client entity
    var newreg = new Clients
    {
        login = UILogin.Text,
        password = hashedpass,
        subscribeid = Convert.ToInt32(UIId.Text),
        //Assigning the details entity (FK) to the client
        ClientDetails = details
    };
    
    //Saving both the client and its details
    user.InsertOnSubmit(newreg);
    user.Context.SubmitChanges();
