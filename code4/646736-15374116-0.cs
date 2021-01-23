    PropertyInfo propertyInfo = form1.Controls.Where(c => c.id == element).FirstOrDefault().GetType().GetProperty(property,
                                BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
        if (propertyInfo != null)
        {
            if (propertyInfo.PropertyType.Equals(value.GetType()))
                propertyInfo.SetValue(control, value, null);
            else
                throw new Exception("Property DataType mismatch, expecting a " +
                                    propertyInfo.PropertyType.ToString() + " and got a " +
                                    value.GetType().ToString());
        }
    }
