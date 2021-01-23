    string sortColumn = e.SortExpression;
        IQueryable<BusinessRisk> sortedList = (from p in this.BusinessRiskList
                                               select new BusinessRisk
                                               {
                                                   BusinessRiskText = p.BusinessRiskText,
                                                   IsActive = p.IsActive,
                                                   Description = p.Description,
                                                   BusinessObjective = new BusinessObjective { BusinessObjectiveText = p.BusinessObjective.BusinessObjectiveText }
                                               }).AsQueryable().OrderBy(e.SortExpression);
        this.BusinessRiskList = sortedList.ToList<BusinessRisk>();
        gvBussinessRisks.DataSource = sortedList;
        gvBussinessRisks.DataBind();
