    mo  //ManagementObject
        .Properties
        .OfType<PropertyData>()
        .ToList()
        .ForEach(p =>
        {
            String str = String.Empty;
            if (p.Value != null)
                 if (p.Value.GetType().BaseType == typeof(Array)) // Value is a array, special string creation
                 {
                     Array list = (p.Value as Array);
                     foreach (object o in list)
                          str += o.ToString() + "-";
                     if (list.Length > 0)
                          str = str.Substring(0, str.Length - 1);
                 }
                 else // value is already a string
                     str = p.Value.ToString();
             this.ListDuet
                 .Add(new Duet()
                 {
                     Key = Convert.ToString(p.Name),
                     Value = str
                 });
         });
