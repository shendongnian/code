    string currentBudgetSection = properties.ListItem["BudgetSection"] == null ? string.Empty : properties.ListItem.GetTaxonomyFieldValueByLanguage(item.Web.Site, "BudgetSection", Thread.CurrentThread.CurrentUICulture.LCID).ToString();
                string newBudgetSection=string.Empty ;
                if (properties.AfterProperties["BudgetSection"] != null && !string.IsNullOrEmpty(properties.AfterProperties["BudgetSection"].ToString()))
                {
                     int startIndex = properties.AfterProperties["BudgetSection"].ToString().IndexOf("#")+1;
                     int endIndex = properties.AfterProperties["BudgetSection"].ToString().IndexOf("|");
                     int length = endIndex - startIndex;
                     newBudgetSection = properties.AfterProperties["BudgetSection"] == null ? string.Empty : properties.AfterProperties["BudgetSection"].ToString().Substring(startIndex, length);
                }
    
    
     bool budgetSectionSame = newBudgetSection.Equals(currentBudgetSection);
                if((!budgetSectionSame )
    //do something
