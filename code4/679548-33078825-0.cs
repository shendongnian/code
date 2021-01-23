    //Sample of Data Contract:
    [DataContract(Name="customer")]
    internal class Customer {
      [DataMember(Name="email")] internal string Email { get; set; }
      [DataMember(Name="name")] internal string Name { get; set; }
    }
    //This is an extension method useful for your case:
    public static string JsonSerialize<T>(this T o)
    {
      MemoryStream jsonStream = new MemoryStream();
      var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
      serializer.WriteObject(jsonStream, o);
      
      var jsonString = System.Text.Encoding.ASCII.GetString(jsonStream.ToArray());
      var props = o.GetType().GetCustomAttributes(false);
      var rootName = string.Empty;
      foreach (var prop in props)
      {
        if (!(prop is DataContractAttribute)) continue;
        rootName = ((DataContractAttribute)prop).Name;
        break;
      }
      jsonStream.Close();
      jsonStream.Dispose();
      if (!string.IsNullOrEmpty(rootName)) jsonString = string.Format("{{ \"{0}\": {1} }}", rootName, jsonString);
      return jsonString;
    }
    //Sample of usage
    var customer = new customer { 
    Name="John",
    Email="john@domain.com"
    };
    var serializedObject = customer.JsonSerialize();
