    foreach (ListItem item in custOptionChkList.Items)
    {
         if (dt.AsEnumerable().Any(row => row.Field<String>("CustomizationId").Equals(item.Value)))
         {
             item.Selected = true;
         }
    }
                      OR
    foreach (ListItem item in custOptionChkList.Items)
    {
         var foundid= dt.Select("CustomizationId = '" + item.Value + "'");
         if (foundid.Length != 0)
         {
             item.Selected = true;
         }
     }
