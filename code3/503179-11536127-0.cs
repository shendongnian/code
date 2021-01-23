    private DependencyProperty GetAttachedProperty(DependencyObject obj, string propertyName, Type ownerType)
    {
        foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(obj,
            new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) }))
        {
            DependencyPropertyDescriptor dpd =
                DependencyPropertyDescriptor.FromProperty(pd);
            if (dpd != null && dpd.IsAttached)
            {
                if (string.Compare(dpd.DependencyProperty.Name, propertyName, StringComparison.CurrentCultureIgnoreCase) == 0 && dpd.DependencyProperty.OwnerType == ownerType)
                {
                    return dpd.DependencyProperty;
                }
            }
        }
        return null;
    }
