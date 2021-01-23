    foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
    {
          if (asm.ManifestModule.FullyQualifiedName.EndsWith("YourDllName.dll"))
          {
                foreach (var Type in asm.GetTypes())
                {
                      // Apply your logic here
                }                
                break;
          }
    }
