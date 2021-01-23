    using (OnlineBankingDataClassesDataContext dataContext = new OnlineBankingDataClassesDataContext())
    {
        tblCustomer customer = GetTopOneCustomer(dataContext); 
        //More Stuff
    }
 
