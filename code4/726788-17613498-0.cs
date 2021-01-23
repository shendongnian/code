    #if NET35
                var evidence = new System.Security.Policy.Evidence();
                evidence.AddHost(new System.Security.Policy.Url(assemblyPath));
                evidence.AddHost(new System.Security.Policy.Zone(System.Security.SecurityZone.MyComputer));
                Assembly assembly = Assembly.LoadFrom(assemblyPath, evidence);                        
    #elif NET40
                var evidence = new System.Security.Policy.Evidence();
                evidence.AddHostEvidence(new System.Security.Policy.Url(assemblyPath));
                evidence.AddHostEvidence(new System.Security.Policy.Zone(System.Security.SecurityZone.MyComputer));
                Assembly assembly = Assembly.LoadFrom(assemblyPath);                        
    #endif
