    var builder = new StringBuilder();
    foreach (var type in typeof(MyClass).GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic))
    {
      if (!type.IsAbstract)
      {
         continue;
      }
      builder.AppendLine(type.Name);
      foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)) {
         var msg = String.Format("{0} = {1}", field.Name, field.GetValue(null));
         builder.AppendLine(msg);
      }
    }
    string output = builder.ToString();
