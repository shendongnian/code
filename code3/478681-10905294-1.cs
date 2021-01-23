    public PropertyDescriptorCollection GetProperties() 
    {
        pdColl = new PropertyDescriptorCollection(null);
        foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(this))
            if (pd.Name != "Dock" && pd.Name != "Anchor")
                pdColl.Add(pd);
        return pdColl;
    }
