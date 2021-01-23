            public void CreateManagedProperty()
        {
            // Get the default service context
            SPServiceContext context = SPServiceContext.GetContext(SPServiceApplicationProxyGroup.Default, SPSiteSubscriptionIdentifier.Default);// Get the search service application proxy
            var searchProxy = context.GetDefaultProxy(typeof(SearchServiceApplicationProxy)) as SearchServiceApplicationProxy;
            // Get the search service application info object so we can find the Id of our Search Service App
            if (searchProxy != null)
            {
                SearchServiceApplicationInfo ssai = searchProxy.GetSearchServiceApplicationInfo();
                // Get the application itself
                var application = SearchService.Service.SearchApplications.GetValue<SearchServiceApplication>(ssai.SearchServiceApplicationId);
                // Get the schema of our Search Service Application
                var schema = new Schema(application);
                // Get all the managed properties
                ManagedPropertyCollection properties = schema.AllManagedProperties;
                // Add a new property
                ManagedProperty myProperty = properties.Create(Constants.ManagedPropertyName, ManagedDataType.Text);
                myProperty.EnabledForScoping = true;
                // Get the current mappings
                MappingCollection mappings = myProperty.GetMappings();
                // Add a new mapping to a previously crawled field
                var myMapping = new Mapping(
                    new Guid(Constants.CrawledPropertyGuid), Constants.CrawledPropertyName, 31, myProperty.PID);
                // Add the mapping
                mappings.Add(myMapping);
                // Update the collection of mappings
                myProperty.SetMappings(mappings);
                // Write the changes back
                myProperty.Update();
            }
        }
