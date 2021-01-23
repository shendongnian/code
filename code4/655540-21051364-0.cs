    public IHttpActionResult DoSomethingWithSupplier(JToken supplier) // Receiving Json Supplier
    {
       // TODO: Get the client version type, for example in the X-API-Version header/query strings
       // (beware, some proxy/hosts strips some headers)
       // Type clientType = ...
    
       var clientSupplier = JsonConvert.DeserializeObject(supplier.ToString(), clientType);
    
	   // You should probably detect latest version automatically (instead of typeof)
	   var latestSupplier = VersionManager.Upgrade(clientSupplier, clientType, typeof(SupplierV5));
    
       outputSupplier = DoSomething(latestSupplier);
       
	   // You should probably detect latest version automatically (instead of typeof)
	   var clientOutputSupplier = VersionManager.Downgrade(outputSupplier, typeof(SupplierV5), clientType);
	   return Ok(clientOutputSupplier);
    }
