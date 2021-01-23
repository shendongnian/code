    struct RoutingCode
    {
      private readonly string routingCode;    
      RoutingCode(string prefix, string service, string sender)
      {
        // Validate prefix, service, sender strings
        // ...
        if (isInvalid) throw ArgumentException();
        this.routingCode = prefix + service + sender;
      }
    
      public string IsValid 
      {
        get { return this.routingCode != null; }
      }
      // Gets the validated routing code.
      public string Routing
      {
        get { return this.routingCode; }
      }
    
      public int RoutingLength
      {
        get { return this.routingCode == null ? 0 : this.routingCode.Length; }
      }
    }
