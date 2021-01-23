     private static void AddIsNullableFieldAttributeOverride(Type type, XmlAttributeOverrides attOv )
        {
            if (attOv == null) throw new ArgumentNullException("attOv");
            if (type == null) throw new ArgumentNullException("type");
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                if (!(prop.PropertyType.IsValueType || Nullable.GetUnderlyingType(prop.PropertyType) != null)) // only mark nullable types
                {
                    XmlAttributes attrs = new XmlAttributes();
                    attrs.XmlElements.Add(new XmlElementAttribute() { IsNullable = true });
                    attOv.Add(type, prop.Name, attrs);
                }
                // traverse nested types
                if (!(prop.PropertyType.IsPrimitive || prop.PropertyType.IsValueType || prop.PropertyType.Namespace == "System")) // only user declared properties and types
                    AddIsNullableFieldAttributeOverride(prop.PropertyType, attOv);
            }
          
        }
