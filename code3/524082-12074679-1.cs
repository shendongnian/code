                    try
                    {
                        // If Value is not a string => Convert over Generic Method
                        MethodInfo method = typeof(whereConvertImplemented).GetMethod("Convert", BindingFlags.NonPublic | BindingFlags.Static);
                        MethodInfo generic = method.MakeGenericMethod(property.PropertyType);
                        var value = generic.Invoke(this, new object[] { propvalue });
                        property.SetValue(this, value, null);
                    }
                    catch
                    {
                    }
