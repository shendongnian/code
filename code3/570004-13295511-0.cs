    SessionClass cqSession = new SessionClass();
    cqSession.UserLogon("user", "pass", "dbname", 2,
    "");
    
    OAdQuerydef queryDef = (OAdQuerydef)
    cqSession.BuildQuery("Issue");
    queryDef.BuildField("id");
    queryDef.BuildField("summary");
    
    OADQUERYFILTERNODE qfn = (OADQUERYFILTERNODE)
    queryDef.BuildFilterOperator(CQConstants.AD_BOOL_OP_AND);
    qfn.BuildFilter("description",
    CQConstants.AD_COMP_OP_LIKE, "foobar");
    
    OAdResultset rs = (OAdResultset)
    cqSession.BuildResultSet(queryDef);
    rs.Execute();
