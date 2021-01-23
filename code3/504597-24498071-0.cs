            MetadataExchangeClientMode mexMode = MetadataExchangeClientMode.HttpGet;
            // Get Metadata file from service
            MetadataExchangeClient mexClient = new MetadataExchangeClient(mexAddress, mexMode);
            mexClient.ResolveMetadataReferences = true;
            MetadataSet metaSet = mexClient.GetMetadata(mexAddress, mexMode);
            //Import all contracts and endpoints
            WsdlImporter importer = new WsdlImporter(metaSet);
            var contracts = importer.ImportAllContracts();
            ServiceEndpointCollection allEndpoints = importer.ImportAllEndpoints();
            //Generate type information for each contract
            ServiceContractGenerator generator = new ServiceContractGenerator();
            this.EndpointsForContracts = new Dictionary<string, IEnumerable<ServiceEndpoint>>();
            foreach (ContractDescription contract in contracts)
            {
                generator.GenerateServiceContractType(contract);
                // Inspect if the name matches one you're looking for, or do whatever
                //  else you might need
            }
    
