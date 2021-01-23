    string messageInfo = string.Format("<{0}>{1}</{0}>",
        parameters.GetType().Name, string.Join("",
            from property in parameters.GetType().GetProperties()
            where property.CanRead
            select string.Format("<{0}>{1}</{0}>",
                property.Name, property.GetValue(parameters, null)));
