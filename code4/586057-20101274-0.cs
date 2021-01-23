        System.Type objType = System.Type.GetTypeFromProgID("Broker.Application");
        dynamic comObject = System.Activator.CreateInstance(objType);
                
        comObject.Import(0, fileName, "default.format");
        comObject.RefreshAll();
