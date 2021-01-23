    var results = from a in searchList
                               where ((a.CreateDt.HasValue &&
                                      a.CreateDt >= Convert.ToDateTime(searchCriteria.BeginDt) &&
                                      a.CreateDt <= Convert.ToDateTime(searchCriteria.EndDt))
                                      && (string.IsNullOrEmpty(searchCriteria.AgentNumber) || a.LgAgentNumber == searchCriteria.AgentNumber)
                                      && (string.IsNullOrEmpty(searchCriteria.AgentTitle) || a.LgTitle == searchCriteria.AgentTitle)
                                      && (string.IsNullOrEmpty(searchCriteria.QuotePolicyNumber) || a.LgTitle == searchCriteria.QuotePolicyNumber)
                                      && (string.IsNullOrEmpty(searchCriteria.InsuredName) || a.LgInsuredName.Contains(searchCriteria.InsuredName))
                                      )
                                select a;
