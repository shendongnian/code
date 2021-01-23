        dynamic locatorObj = Activator.CreateInstance(Type.GetTypeFromProgID(("WbemScripting.SWbemLocator")));
        dynamic providerObj = locatorObj.ConnectServer("MyMachine", "root/MicrosoftIISv2");  
        dynamic computerObj = providerObj.get("IIsComputer='LM'");
        
        computerObj.Import(strPassword, strFilePath, strSourceMetabasePath, strDestinationMetabasePath, intFlags);  
