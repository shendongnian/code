                    if (p.Name == "PropertyName")
                        property = p;
                }
                if (property == null)
                {
                    property = storageItem.UserProperties.Add("PropertyName", Outlook.OlUserPropertyType.olText, false,
                                                              Outlook.OlDisplayType.olUser);
                }
                property.Value = "my_value_can_contain[brackets]";
                storageItem.Save();
