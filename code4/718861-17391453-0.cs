    foreach (IAspect asp in Policy.Aspects)
    {
        policy.AddMatchingRule(ruleLog)
          .AddCallHandler(asp.CallHandlerType, 
            new ContainerControlledLifetimeManager());
    }
