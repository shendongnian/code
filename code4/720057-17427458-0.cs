    public Binding ResolveBinding(string name)
        {
        Configuration appConfig = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
    ServiceModelSectionGroup serviceModel = ServiceModelSectionGroup.GetSectionGroup(appConfig);
    
          BindingsSection section = serviceModel.Bindings;
        
          foreach (var bindingCollection in section.BindingCollections)
          {
            if (bindingCollection.ConfiguredBindings.Count > 0 
        
        && bindingCollection.ConfiguredBindings[0].Name == name)
            {
              var bindingElement = bindingCollection.ConfiguredBindings[0];
              var binding = (Binding)Activator.CreateInstance(bindingCollection.BindingType);
              binding.Name = bindingElement.Name;
              bindingElement.ApplyConfiguration(binding);
        
              return binding;
            }
          }
        
          return null;
        }
            
    public List<IEndpointBehavior> ResolveEndpointBehavior(string name)
    {
         Configuration appConfig = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
    ServiceModelSectionGroup serviceModel = ServiceModelSectionGroup.GetSectionGroup(appConfig);
    
          BindingsSection section = serviceModel.Behaviors;
      List<IEndpointBehavior> endpointBehaviors = new List<IEndpointBehavior>();
    
      if (section.EndpointBehaviors.Count > 0 
    
    && section.EndpointBehaviors[0].Name == name)
      {
        var behaviorCollectionElement = section.EndpointBehaviors[0];
    
        foreach (BehaviorExtensionElement behaviorExtension in behaviorCollectionElement)
        {
          object extension = behaviorExtension.GetType().InvokeMember("CreateBehavior",
                BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance,
                null, behaviorExtension, null);
    
          endpointBehaviors.Add((IEndpointBehavior)extension);
        }
    
       return endpointBehaviors;
     }
    
     return null;
    }
