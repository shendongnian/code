    internal static void InitReferencedContracts(Options options, WsdlImporter importer, ServiceContractGenerator contractGenerator)
    {
        foreach (Type type in options.ReferencedTypes)
        {
            if (type.IsDefined(typeof(ServiceContractAttribute), false))
            {
                try
                {
                    ContractDescription contract = ContractDescription.GetContract(type);
                    XmlQualifiedName key = new XmlQualifiedName(contract.Name, contract.Namespace);
                    importer.KnownContracts.Add(key, contract);
                    contractGenerator.ReferencedTypes.Add(contract, type);
                    continue;
                }
                catch (Exception exception)
                {
                    if (Tool.IsFatal(exception))
                    {
                        throw;
                    }
                    throw new ToolRuntimeException(SR.GetString("ErrUnableToLoadReferenceType", new object[] { type.AssemblyQualifiedName }), exception);
                }
            }
        }
    }
 
 
