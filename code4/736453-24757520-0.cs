    private bool PropertyHasAttribute<T>(string properyName, Type attributeType)
        {
            MetadataTypeAttribute att = (MetadataTypeAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(MetadataTypeAttribute));
            if (att != null)
            {
                ;
                foreach (var prop in Type.GetType(att.MetadataClassType.UnderlyingSystemType.FullName).GetProperties())
                {
                    if (properyName.ToLower() == properyName.ToLower() && Attribute.IsDefined(prop,attributeType))
                        return true;
                }
            }
            return false;
        }
