        //Get the current binding 
        System.ServiceModel.Channels.Binding binding = client.Endpoint.Binding;
        //Get the binding elements 
        BindingElementCollection elements = binding.CreateBindingElements();
        //Locate the Security binding element
        SecurityBindingElement security = elements.Find<SecurityBindingElement>();
        //This should not be null - as we are using Certificate authentication anyway
        if (security != null)
        {
       	UserNameSecurityTokenParameters uTokenParams = new UserNameSecurityTokenParameters();
        uTokenParams.InclusionMode = SecurityTokenInclusionMode.AlwaysToRecipient;
	security.EndpointSupportingTokenParameters.SignedEncrypted.Add(uTokenParams);
        }
       client.Endpoint.Binding = new CustomBinding(elements.ToArray());
