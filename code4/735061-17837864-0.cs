    var t= typeof(Constants).GetFields(BindingFlags.Static | BindingFlags.Public)
                        .Where(f => f.IsLiteral).
    foreach (var fieldInfo in t)
    {
       // name of the const
       var name = fieldInfo.Name;
    
       // value of the const
       var value = fieldInfo.GetValue(null);
    }
