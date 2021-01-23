    private static void GenerateNewPingMethod(ServiceHost sh)
    {
        foreach (var endpoint in sh.Description.Endpoints)
        {
    
            ContractDescription contract = endpoint.Contract;
    
            OperationDescription operDescr = new OperationDescription("Ping", contract);
    
            MessageDescription inputMsg = new MessageDescription(contract.Namespace + contract.Name + "/Ping", MessageDirection.Input);
    
            MessageDescription outputMsg = new MessageDescription(contract.Namespace + contract.Name + "/PingResponse", MessageDirection.Output);
    
            MessagePartDescription retVal = new MessagePartDescription("PingResult", contract.Namespace);
    
            retVal.Type = typeof(DateTime);
    
            outputMsg.Body.WrapperName = "PingResponse";
            outputMsg.Body.WrapperNamespace = contract.Namespace;
            outputMsg.Body.ReturnValue = retVal;
            
    
            operDescr.Messages.Add(inputMsg);
            operDescr.Messages.Add(outputMsg);
            operDescr.Behaviors.Add(new DataContractSerializerOperationBehavior(operDescr));
            operDescr.Behaviors.Add(new PingImplementationBehavior());
            contract.Operations.Add(operDescr);
        }
    }
