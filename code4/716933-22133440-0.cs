        using (var context = new workEntities() )
    {
    
        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
        dictionary["Title"] = new List<string> {  
                        "Network Engineer", 
                        "Security Specialist", 
                        "=Web Developer"
                    };
        dictionary["Salary"] = new List<string> { ">=2000" };
        dictionary["VacationHours"] = new List<string> { ">21" };
        dictionary["SickLeaveHours"] = new List<string> { "<5" };                
        dictionary["HireDate"] = new List<string> { 
                        ">=01/01/2000",
                        "28/02/2014" 
                    };
        dictionary["ModifiedDate"] = new List<string> { DateTime.Now.ToString() };
    
        var data = context.Employee.CollectionToQuery(dictionary).ToList();
    }
