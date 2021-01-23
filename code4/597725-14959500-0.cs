    using (SPSite oSPsite = new SPSite("http://hostsite.host/sites/SearchAdministration"))
            {
                SPServiceContext context = SPServiceContext.GetContext(oSPsite);                
                // Get the search service application proxy
                SearchServiceApplicationProxy searchProxy = context.GetDefaultProxy(typeof(SearchServiceApplicationProxy)) as SearchServiceApplicationProxy;
                // Get the search service application info object so we can find the Id of our Search Service App
                SearchServiceApplicationInfo ssai = searchProxy.GetSearchServiceApplicationInfo();
                // Get the application itself
                SearchServiceApplication application = Microsoft.Office.Server.Search.Administration.SearchService.Service.SearchApplications.GetValue<SearchServiceApplication>(ssai.SearchServiceApplicationId);
                    //Microsoft.Office.Server.Search.Administration.SearchService.Service.SearchApplications.GetValue<SearchServiceApplication>(ssai.SearchServiceApplicationId);
                Microsoft.Office.Server.Search.Administration.Query.FederationManager fedManager = new Microsoft.Office.Server.Search.Administration.Query.FederationManager(application);
                SearchObjectOwner owner = new SearchObjectOwner(SearchObjectLevel.SPSite, oSPsite.RootWeb);
                Source currentResultSource = fedManager.CreateSource(owner);
                currentResultSource.Name = "Test Result Source ";
                currentResultSource.ProviderId = fedManager.ListProviders()["Local SharePoint Provider"].Id;
                currentResultSource.Commit();
            }  
