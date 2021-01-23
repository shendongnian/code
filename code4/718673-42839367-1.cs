                bool hasLanguage = !string.IsNullOrEmpty(language);
                if (hasLanguage)
                {
                    var attribute = (LocalizedDescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(LocalizedDescriptionAttribute));
                    if (attribute != null)
                    {
                        description = attribute.GetDescription(language);
                    }
                    else
                        hasLanguage = false;
                }
                if (!hasLanguage)
                {
                    var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
                    if (attribute != null)
                    {
                        description = attribute.Description;
                    }
                }
