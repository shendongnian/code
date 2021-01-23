    var criteria = _session.QueryOver<Customer>(() => c)
        .JoinAlias(() => c.CompanyCustomerAssignment, () => cca)
        .Where(() => cca.Company == currentCompany && c.IsActive == true);
    
    // if during the query build
    if(custGrp != null)
    {
      criteria.Where(() => cca.CustomerGroup == custGrp);
    }
    
    var results = criteria
        .List()
        ... 
