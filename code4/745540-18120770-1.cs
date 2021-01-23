    DynamicTypeDescriptor dtp = new DynamicTypeDescriptor(typeObj);
    // get current property definition and remove it
    var current = dtp.Properties["ThePropertyToChange"];
    dtp.RemoveProperty("ThePropertyToChange");
    // add a new one, but change its display name
    DynamicTypeDescriptor.DynamicProperty prop = new DynamicTypeDescriptor.DynamicProperty(dtp, current, obj);
    prop.SetDisplayName("MyNewPropertyName");
    dtp.AddProperty(prop);
    propertyGrid1.SelectedObject = dtp.FromComponent(obj);
