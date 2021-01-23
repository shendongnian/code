    Type clientProxyType = this.Cr.CompiledAssembly.GetTypes().First(t => t.IsClass && t.GetInterface(listServiceContracts.SelectedValue) != null && t.GetInterface(typeof(ICommunicationObject).Name) != null);
    object dataContract = this.Cr.CompiledAssembly.CreateInstance(dataContractType.FullName, false, System.Reflection.BindingFlags.CreateInstance, null, null, CultureInfo.CurrentCulture, null);
    // set the dataContract properties however they need to be set
    // Get the first service endpoint for the contract
            ServiceEndpoint serviceEndPoint = this.EndpointsForContracts[listServiceContracts.SelectedValue].First();
            object clientProxyInstance = this.Cr.CompiledAssembly.CreateInstance(clientProxyType.Name, false, System.Reflection.BindingFlags.CreateInstance, null, new object[] { serviceEndPoint.Binding, serviceEndPoint.Address }, CultureInfo.CurrentCulture, null);
            Type myType = clientProxyInstance.GetType();
            object[] arg = { dataContract };
            // Now call the remote procedure via SOAP, get back response
            var returnVal = myType.InvokeMember("OPERATION YOU WANT TO EXECUTE", BindingFlags.InvokeMethod, null, clientProxyInstance, arg);
