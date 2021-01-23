      var binding = new System.ServiceModel.BasicHttpBinding();
      uri = new Uri(/*the correct uri for the service*/);
      address = new System.ServiceModel.EndpointAddress(u);
      CustomBinding cbinding = new CustomBinding(binding);
      foreach (BindingElement be in cbinding.Elements)
      {
          if (be is HttpTransportBindingElement) ((HttpTransportBindingElement)be).KeepAliveEnabled = false;
      }
      service = new PositioningControlPortTypeClient(cbinding, address);
