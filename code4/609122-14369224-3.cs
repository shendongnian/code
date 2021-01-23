    // This will change the DataMember.Name at runtime!
    // This will only work if you know the node name in advance.
    static void SetUserDefinedNodeName(string userDefinedNodeName)
    {
      var type = typeof(AddressList);
      var property = type.GetProperty("UserDefined", BindingFlags.Default);
      var attribute = property.GetCustomAttribute<DataMemberAttribute>();
      if (attribute != null)
        attribute.Name = userDefinedNodeName;
    }
    static T Deserialize<T>(string jsonText, string userDefinedNodeName)
    {
      SetUserDefinedNodeName(userDefinedName);
      var jsonBytes = Encoding.UTF8.GetBytes(jsonText);
      using (var stream = new MemoryStream(jsonBytes))
      {
        var serializer = new DataContractJsonSerializer(typeof(T));  
        var obj = serializer.ReadObject(stream) as T;
        return obj;
      }
    }
