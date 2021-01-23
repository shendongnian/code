        var locatorObj = Activator.CreateInstance(Type.GetTypeFromProgID(("WbemScripting.SWbemLocator")));
        var providerObj = locatorObj._I("ConnectServer", "MyMachine", "root/MicrosoftIISv2");  
        var computerObj = providerObj._I("get", "IIsComputer='LM'");
        
        computerObj._I("Import", strPassword, strFilePath, strSourceMetabasePath, strDestinationMetabasePath, intFlags);  
    public static class ReflectionHlp
    {
      public static object _I(this object item, string name, params object[] args)
      {
        if (item == null)
          return null;
        return item.GetType().InvokeMember(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, item, args);
      }
    }
