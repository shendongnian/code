          Dim binding As New WebHttpBinding(WebHttpSecurityMode.Transport)
          binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None
        
          ChlFactory = New WebChannelFactory(Of IMyServiceContract)(binding, New Uri(url))
          ChlFactory.Endpoint.Behaviors.Add(New WebHttpBehavior())
          ChlFactory.Endpoint.Behaviors.Add(New AuthenticationHeaderBehavior(user, pass))
          Channel = ChlFactory.CreateChannel()
