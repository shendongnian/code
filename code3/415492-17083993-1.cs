    try {
      if (this.IsHostedInAspnet()) {
        object[] args = new object[] { this.Property, this, ex };
        Type type = Type.GetType("System.Web.Management.WebBaseEvent, System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", true);
        type.InvokeMember("RaisePropertyDeserializationWebErrorEvent", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, null, args, CultureInfo.InvariantCulture);
      }
    }
    catch {
    }
