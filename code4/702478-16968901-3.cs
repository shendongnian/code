    public Create(SPFeatureReceiverProperties properties, Dictionary<string, AddParams> columns, string name, string description, SPListTemplateType type)
    {
        SPSite siteCollection = properties.Feature.Parent as SPSite;
        if (siteCollection != null)
        {
            SPWeb web = siteCollection.RootWeb;
            web.Lists.Add(name, description, type);
            web.Update();
    
            // Add the new list and the new content.
            SPList spList = web.Lists[name];
            foreach(string key in columns.Keys){
                spList.Fields.Add(key, columns[key].type, columns[key].required);
            }
    
            // More Code ...
        }
    }
