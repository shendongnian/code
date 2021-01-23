    MemberInfo[] members = providerType.GetMember(
     providerName,
     MemberTypes.Field | MemberTypes.Method | MemberTypes.Property,
     BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        
    if (members.Length == 0)
     throw new Exception(string.Format(
      "Unable to locate {0}.{1}", providerType.FullName, providerName));
