    for (int i = 0; i < keys.Count; i++)
    {
     this.GetType().InvokeMember(keys[i],
         BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
         Type.DefaultBinder, obj, row[i]);
    }
