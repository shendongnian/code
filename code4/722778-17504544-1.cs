            obj.GetType().GetPublicProperties().ForEach((property) =>
                {
                    if (property.GetGetMethod().ReturnType == typeof(string))
                    {
                        string value = (string)property.GetValue(obj, null);
                        if (value == null)
                            property.SetValue(obj, string.Empty, null);
                    }
                }
