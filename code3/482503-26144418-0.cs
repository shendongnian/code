            static public void UpdateAttributes(object self)
        {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(self))
            {
                LocalDisplayNameAttribute attr =
                    prop.Attributes[typeof(LocalDisplayNameAttribute)] 
                        as LocalDisplayNameAttribute;
                if (attr == null)
                {
                    continue;
                }
                attr.ResourceKey = prop.Name;
            }
        }
