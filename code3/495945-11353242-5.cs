    SqlDataSource1.FilterExpression = string.Empty;
    List<string> subscriptionTypeFilter = new List<string>();
    if (MonthlyCheckBox.Checked)
    {
        subscriptionTypeFilter.Add("[CustomerSubscriptionType]='Monthly'");
    }
    if (SemiAnnuallyCheckBox.Checked)
    {
        subscriptionTypeFilter.Add("[CustomerSubscriptionType]='Semi-Annually'");
    }
    if (AnnuallyCheckBox.Checked)
    {
	subscriptionTypeFilter.Add("[CustomerSubscriptionType]='Annually'");
    }
		
    List<string> customerStatusFilter = new List<string>();
    if (NewCheckBox.Checked)
    {
	subscriptionTypeFilter.Add("[CustomerStatus]='New'");             
    }
		
    if (ActiveCheckBox.Checked)
    {
	subscriptionTypeFilter.Add("[CustomerStatus]='Active'");
    }
		
    if (SuspendedCheckBox.Checked)
    {
	subscriptionTypeFilter.Add("[CustomerStatus]='Suspended'");
    }
		
		
    List<string> filters = new List<string>();
	
    filters.Add("(" + string.Join(" OR ", subscriptionTypeFilter) + ")");
    filters.Add("(" + string.Join(" OR ", customerStatusFilter) + ")");
		
    SqlDataSource1.FilterExpression = string.Join(" AND ", filters);      
