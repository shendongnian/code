    var dict = new Dictionary<Customer, Form>();
    var cust = new Customer();
    
    if(!dict.ContainsKey(cust) || dict[cust].IsDisposed)
    {
        dict[cust] = new Form1();
    }
    
    dict[cust].Show();
    dict[cust].Activate();
