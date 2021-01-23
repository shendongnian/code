    CustomerDetailsStruct cd = CustomerDetailsAccess.GetCustomerDetails(customerId);
    
    //FormView DataSource has to be IListSource, IEnumerable, or IDataSource
    List<CustomerDetailsStruct> list = new List<CustomerDetailsStruct>();
    list.Add(cd);
    FormView.DataSource = list;
    //Choose the proper mode (templates have to be defined) 
    FormView.ChangeMode(FormViewMode.ReadOnly);
    FormView.DataBind();
