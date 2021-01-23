    Model.Order orderAlias = null;
    Model.Unit unitsAlias = null;
    Model.Employee employeeAlias = null;
    
    IList<Model.Unit> itemList = null;
    
    using (m_hibernateSession.BeginTransaction())
    {
        IQueryOver<Model.Order, Model.Order> orderQuery = m_hibernateSession.QueryOver<Model.Order>();
    
        // order related filters
        if (propertiesNames.Keys.Contains("OrderPONumber")) orderQuery.Where(o => o.PONumber == Int32.Parse((string)propertiesNames["OrderPONumber"]));
    
        // retrieve amount of orders (e.g. 5)
        orderQuery.Where(o => o.PONumber != 0).Select(o => o.ID).OrderBy(o => o.PONumber).Desc.Take(amount); 
        
        int[] orderIDList = orderQuery.List<int>().ToArray(); // get ID list of filtered orders
        IQueryOver<Model.Unit, Model.Unit> query = m_hibernateSession.QueryOver<Model.Unit>(() => unitsAlias)                                        
                            .WhereRestrictionOn(o => o.OrderRef.ID).IsIn(orderIDList) // set order ID range
                            .JoinAlias(() => unitsAlias.EmployeeRef, () => employeeAlias, JoinType.InnerJoin);
    
        // additional filters
        if (propertiesNames.Keys.Contains("CostCenter")) query.Where(() => unitsAlias.CostCenter == (string)propertiesNames["CostCenter"]);                
        if (propertiesNames.Keys.Contains("Employee")) query.Where(Restrictions.On(() => employeeAlias.Name).IsLike( "%" + (string)propertiesNames["Employee"] + "%"));
    
    
        itemList = query.List<Model.Unit>();
    }
