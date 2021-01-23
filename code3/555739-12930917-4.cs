      PropertyInfo pInfo = myObject.GetType().GetProperty("MyDataSource");
      if (pInfo != null && pInfo.PropertyType.FullName.StartsWith("System.Collections"))
      {
        foreach (object obj in ((IEnumerable)pInfo.GetValue(myObject, null)))
        {
          PropertyInfo pInfoElement = obj.GetType().GetProperty("MyList");
        }
      }
