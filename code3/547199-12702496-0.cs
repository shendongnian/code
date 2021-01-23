    //In Site Map 
    
        <siteMapNode title="Shipping rate" nopResource="Admin.Configuration.Shipping.Rate" controller="Shipping" action="SomeAction"/> 
    //In Shipping Controller 
     
    
        public ActionResult SomeAction()
        {
             return RedirectToAction("ConfigureProvider", new { systemName = "Shipping.ByWeight" });
        }
        
        
        public ActionResult ConfigureProvider(string systemName)
        {
        
        }
