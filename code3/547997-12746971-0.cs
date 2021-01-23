    ICOMAdminCatalog2 oCatalog = (ICOMAdminCatalog2) Activator.CreateInstance(Type.GetTypeFromProgID("ComAdmin.COMAdminCatalog"));
    		
    ICatalogCollection applications = oCatalog.GetCollection("Applications");
    applications.Populate();
    foreach (ICatalogObject applicationInstance in applications)
    {
    	ICatalogCollection comps = applications.GetCollection("Components", applicationInstance.Key);
    	comps.Populate();
    	foreach (ICatalogObject comp in comps)
    	{
    		Console.WriteLine("{0} - {1}", comp.Name, comp.Key);
    	}
    }
