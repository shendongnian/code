    process  = _session.CreateCriteria<Process>()
        .Add(Restrictions.Eq("Id", loadingProcessId))
        .CreateCrtieria("Parameters")
        .CreateCrtieria("SourceSystem", "SourceSystem")
        .AddOrder(Order.Asc("SourceSystem.Name"))
        .UniqueResult<Process>();
