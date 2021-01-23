     var assemblyInfo = AssemblyName.GetAssemblyName(pathToMyAssembly); //get assembly
     Version assemblyVersion = assemblyInfo.Version; // get version
     Version minVersion = new Version(1, 1, 4); // minimum version of 1.1.4
     if (minVersion.CompareTo(assemblyVersion) < 0)
           // the version is less than the minimum.
           // do something to reconcile problem
