            Uri mexAddress = new Uri(URL);
            // For MEX endpoints use a MEX address and a 
            // mexMode of .MetadataExchange
            MetadataExchangeClientMode mexMode = MetadataExchangeClientMode.HttpGet;
            var binding = new WSHttpBinding(SecurityMode.None);
            binding.MaxReceivedMessageSize = Int32.MaxValue;
            XmlDictionaryReaderQuotas readerQuotas = new XmlDictionaryReaderQuotas();
            readerQuotas.MaxNameTableCharCount = Int32.MaxValue;
            binding.ReaderQuotas = readerQuotas;
            //SS Get Service Type and set this type to either Galba and Powersale
            string contractName = "";
             string operationName = "RegisterMerchant";
            object[] operationParameters;// = new object[] { 1, 2 };
            // Get the metadata file from the service.
            //MetadataExchangeClient mexClient = new MetadataExchangeClient(mexAddress, mexMode);
            MetadataExchangeClient mexClient = new MetadataExchangeClient(binding);
            mexClient.ResolveMetadataReferences = true;
            MetadataSet metaSet = mexClient.GetMetadata(mexAddress, mexMode);
            // Import all contracts and endpoints
            WsdlImporter importer = new WsdlImporter(metaSet);
            Collection<ContractDescription> contracts = importer.ImportAllContracts();
            ServiceEndpointCollection allEndpoints = importer.ImportAllEndpoints();
            // Generate type information for each contract
            ServiceContractGenerator generator = new ServiceContractGenerator();
            var endpointsForContracts = new Dictionary<string, IEnumerable<ServiceEndpoint>>();
            foreach (ContractDescription contract in contracts)
            {
                generator.GenerateServiceContractType(contract);
                // Keep a list of each contract's endpoints
                endpointsForContracts[contract.Name] = allEndpoints.Where(se => se.Contract.Name == contract.Name).ToList();
            }
            if (generator.Errors.Count != 0) { throw new Exception("There were errors during code compilation."); }
            // Generate a code file for the contracts 
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            CodeDomProvider codeDomProvider = CodeDomProvider.CreateProvider("C#");
            // Compile the code file to an in-memory assembly
            // Don't forget to add all WCF-related assemblies as references
            CompilerParameters compilerParameters = new CompilerParameters(
                new string[] { "System.dll", "System.ServiceModel.dll", "System.Runtime.Serialization.dll" });
            compilerParameters.GenerateInMemory = true;
            CompilerResults results = codeDomProvider.CompileAssemblyFromDom(compilerParameters, generator.TargetCompileUnit);
            if (results.Errors.Count > 0)
            {
                throw new Exception("There were errors during generated code compilation");
            }
            else
            {
                // Find the proxy type that was generated for the specified contract
                // (identified by a class that implements 
                // the contract and ICommunicationbject)
                Type[] types = results.CompiledAssembly.GetTypes();
                Type clientProxyType = types
                    .First(t => t.IsClass && t.GetInterface(contractName) != null && t.GetInterface(typeof(ICommunicationObject).Name) != null);
               
                // Get the first service endpoint for the contract
                ServiceEndpoint se = endpointsForContracts[contractName].First();
                // Create an instance of the proxy
                // Pass the endpoint's binding and address as parameters
                // to the ctor
                object instance = results.CompiledAssembly.CreateInstance(
                    clientProxyType.Name,
                    false,
                    System.Reflection.BindingFlags.CreateInstance,
                    null,
                    new object[] { se.Binding, se.Address },
                    CultureInfo.CurrentCulture, null);
                    Type parameterType = types.First(t => t.IsClass && t.Name=="Method()");
                    Object o = Activator.CreateInstance(parameterType);
                    FieldInfo[] props = parameterType.GetFields();
                    FieldInfo fi = parameterType.GetField("NewMerchantDetail");
                    //PropertyInfo pi = parameterType.GetProperty("NewMerchantDetail");
                    Type p1Type = fi.FieldType;
                    //Pass in the values here!!!
                    Object o1 = Activator.CreateInstance(p1Type);
                    PropertyInfo pi1 = p1Type.GetProperty("MerchantID");//7
                    pi1.SetValue(o1, vendingClient.VendingClientID, null);
                    pi1 = p1Type.GetProperty("FirstName");// John  
                    pi1.SetValue(o1, vendingClient.DescriptiveName, null);
                    fi.SetValue(o, o1, BindingFlags.Default, null, null);
                    operationParameters = new object[] { o1 };
                    // Get the operation's method, invoke it, and get the return value
                    object retVal = instance.GetType().GetMethod(operationName).
                        Invoke(instance, operationParameters);
