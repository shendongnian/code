    public static List<string> OrganizeParams(vw_UserManager_Model model)
    {
         List<string> myParams = new List<string>();
    
        foreach (var property in model.GetType().GetProperties())
        {
            switch (property.PropertyType.GenericTypeArguments.FirstOrDefault().Name.ToString())
            {
                case "String":
                    myParams.Add("System.String" + ":" + property.GetValue(model, null));
                    break;
                case "Guid":
                    myParams.Add("System.Guid" + ":" + property.GetValue(model, null));
                    break;
                case "Int32":
                    myParams.Add("System.Int32" + ":" + property.GetValue(model, null));
                    break;
                case "Boolean":
                    myParams.Add("System.Boolean" + ":" + property.GetValue(model, null));
                    break;
            }
        }
        return myParams;
    }
