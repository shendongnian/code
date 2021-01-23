    var query = new QueryExpression
                {
                    EntityName = "new_typedecontrat",
                    ColumnSet = new ColumnSet { AllColumns = true },
                    Criteria = new FilterExpression
                    {
                        FilterOperator = LogicalOperator.And
                    }
                };
                var expression2 = new ConditionExpression("new_typedecontratid",   ConditionOperator.Equal, campaign.New_TypedecontratId.Id);
    
                query.Criteria.Conditions.Add(expression2);
    
                EntityCollection entitys = CRM.Instance.RetrieveMultiple(query);
    try
                {
                    using (var serviceProxy1 = new OrganizationServiceProxy(organizationUri, homeRealmUri, credentials, null))
                    {
                        // This statement is required to enable early-bound type support.
                        serviceProxy1.ServiceConfiguration.CurrentServiceEndpoint.Behaviors.Add(new ProxyTypesBehavior());
                        serviceProxy1.Timeout = new TimeSpan(0, 10, 0);
                        CRMService = serviceProxy1;
                        
                        return CRMService.RetrieveMultiple(query);
                    }
                }
