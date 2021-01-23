    Order k = new Order(){ID=5}; // create order with ID of 5
    IsolatedStorageSettings.ApplicationSettings.Add("mykey", k); // Save to ISO
    IsolatedStorageSettings.ApplicationSettings.Save();
    Order m = (Order)((Order)IsolatedStorageSettings.ApplicationSettings["myKey"]).Clone(); // M = 5
    m.ID = 6; // Change ID number
    m = (Order)((Order)IsolatedStorageSettings.ApplicationSettings["myKey"]).Clone(); // M = 5
