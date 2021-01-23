        ISite currentSite = ((MultisiteContext) SystemManager.CurrentContext).CurrentSite;
        var providers = currentSite.GetProviders("YourModuleName").Select(p => p.ProviderName).ToList();
        foreach (string provider in providers)
        {       
            var dynamicType = TypeResolutionService.ResolveType("Fully.Qualified.Name.Of.Your.Dynamic.Type");
            if (dynamicType != null)
            {
                using (var manager = DynamicModuleManager.GetManager(providerName))
                {
                    var dynamicTypeItems = manager.GetDataItems(dynamicType).Where(p =>
                        p.Status == ContentLifecycleStatus.Live && p.Visible).ToList();
                    foreach (var item in dynamicTypeItems)
                    {
                        var location = SystemManager.GetContentLocationService().GetItemDefaultLocation(item);
                        if (location != null)
                        {
                            var fullUrl = location.ItemAbsoluteUrl;
                            // Then append to sitemap (if page is live/visible/frontend)                    
                        }
                    }
                }
            }
        }
