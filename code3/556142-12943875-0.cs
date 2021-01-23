    foreach (SPService service in SPFarm.Local.Services)
    {
        if (service is SearchService)
        {
            SearchService searchService = (SearchService)service;
            foreach (SearchServiceApplication ssa in searchService.SearchApplications)
            {
                Schema schema = new Schema(ssa);
                foreach (ManagedProperty property in schema.AllManagedProperties)
                {
                    if (property.Name == "ContentType")
                    {
                        //Handle here
                    }
                }
            }
        }
    }
