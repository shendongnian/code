    private static void Process(
            KeyValuePair<string, dynamic> kvPair,
            ref CommonBase cObject)
    {
        var propertyInfo = typeof(CommonBase).GetProperty(kvPair.Key);
        switch (propertyInfo.PropertyType.FullName)
        {
            case "System.Int32":
                propertyInfo
                    .SetValue(cObject,
                        (int)propertyInfo.GetValue(cObject) + (int)kvPair.Value);
                break;
        }
    }
