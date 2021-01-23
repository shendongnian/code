            var type = typeof(T);
            foreach (var property in type.GetProperties())
            {
                var attributes = property.GetCustomAttributes(typeof(PathToXmlNode), true);
                if (attributes != null && attributes.Length > 0)
                {
                    //this property has this attribute assigned.
                    //get the value to assign
                    var xmlAttribute = (PathToXmlNode)attributes[0];
                    var node = doc.SelectSingleNode(xmlAttribute.Path, nmgr);
                    if (node != null && !string.IsNullOrWhiteSpace(node.InnerText))
                    {
                        dynamic castedValue;
                        if (property.PropertyType == typeof(bool))
                        {
                            castedValue = Convert.ToBoolean(node.InnerText);
                        }
                        ...Snip all the casts....
                        else
                        {
                            castedValue = node.InnerText;
                        }
                      
                        //we now have the node and it's value, now set it to the property.
                        property.SetValue(obj, castedValue, System.Reflection.BindingFlags.SetProperty, null, null, System.Globalization.CultureInfo.CurrentCulture);
                    }
                }
            }
