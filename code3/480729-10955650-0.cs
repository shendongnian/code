            Rule f;
            var type = typeof(Rule);
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == "description")
                        f = (Rule)field.GetValue(null);
                    break;
                }
                else
                {
                    if (field.Name == "description")
                        f = (Rule)field.GetValue(null);
                    break;
                }
            } 
