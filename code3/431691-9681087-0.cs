    // Load snippet item
    Item snippet = Sitecore.Context.Database.GetItem("{id-or-path-of-snippet-item}");
    
    // Get the first rendering from item's presentation definition
    RenderingReference rendering = snippet.Visualization.GetRenderings(Sitecore.Context.Device, false).FirstOrDefault();
    
    // We assume that its a Sublayout, but you can also check for xslt and create an XslFile() object
    Sublayout sublayout = new Sublayout();
    sublayout.DataSource = snippet.Paths.FullPath; // creates a reference to the snippet item, so you can pull data from that later on
    sublayout.Path = rendering.RenderingItem.InnerItem["Path"];
    sublayout.Cacheable = rendering.RenderingItem.Caching.Cacheable;
    
    // Copy cache settings
    if (rendering.RenderingItem.Caching.Cacheable)
    {
    	sublayout.VaryByData = rendering.RenderingItem.Caching.VaryByData;
    	sublayout.VaryByDevice = rendering.RenderingItem.Caching.VaryByDevice;
    	sublayout.VaryByLogin = rendering.RenderingItem.Caching.VaryByLogin;
    	sublayout.VaryByParm = rendering.RenderingItem.Caching.VaryByParm;
    	sublayout.VaryByQueryString = rendering.RenderingItem.Caching.VaryByQueryString;
    	sublayout.VaryByUser = rendering.RenderingItem.Caching.VaryByUser;
    }
    
    // Now render the sublayout to the placeholder
    phSideBarPlaceHolder.Controls.Add(sublayout);
