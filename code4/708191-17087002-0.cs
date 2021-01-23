    public static TimeZoneInfo GetUserTimeZone(IOrganizationService service, Guid userId)
    {
        int timeZoneCode = 35; //default timezone to eastern just incase one doesnt exists for user
        var userSettings = service.Retrieve(UserSettings.EntityLogicalName, userId, new ColumnSet("timezonecode")).ToEntity<UserSettings>();
        
        if ((userSettings != null) && (userSettings.TimeZoneCode != null))
        {
            timeZoneCode = userSettings.TimeZoneCode.Value;
        }
        
        return GetTimeZone(service, timeZoneCode);
    }
    
    public static TimeZoneInfo GetTimeZone(IOrganizationService service, int crmTimeZoneCode)
    {
        var qe = new QueryExpression(TimeZoneDefinition.EntityLogicalName);
        qe.ColumnSet = new ColumnSet("standardname");
        qe.Criteria.AddCondition("timezonecode", ConditionOperator.Equal, crmTimeZoneCode);
        return TimeZoneInfo.FindSystemTimeZoneById(service.RetrieveMultiple(qe).Entities.First().ToEntity<TimeZoneDefinition>().StandardName);
    }
