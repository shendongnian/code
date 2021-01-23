    NameValueCollection queryString = helper.ViewContext.HttpContext.Request.QueryString;
    foreach (string key in queryString)
    {
       if (key != null)
       {
           if (!newValues.ContainsKey(key))
           {
               if (!string.IsNullOrEmpty(queryString[key]))
               {
                    newValues[key] = queryString[key];
               }
            }
       }
    }
