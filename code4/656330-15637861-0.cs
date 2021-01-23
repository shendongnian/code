    public CustomerVO(Customer item)
    {
        CustomerID = item.CustomerID;
        CustomerName = item.CustomerName;
        ECNNumber = item.ECNNumber;
        **CustomerBackgroundLevels = item.CustomerBackgroundLevels.Select(c => new CustomerBackgroundLevelVO(c,this)).ToList();
    }
    **public CustomerBackgroundLevelVO(CustomerBackgroundLevel item, CustomerVO vocustomer)
    {
        CustomerBackgroundLevelID = item.CustomerBackgroundLevelID;
        CustomerID = item.CustomerID;
        BackgroundLevelID = item.BackgroundLevelID;
        StartDate = item.StartDate;
        EndDate = item.EndDate;
        **Customer = vocustomer;
        BackgroundLevel = new BackgroundLevelVO(item.BackgroundLevel);
    }
