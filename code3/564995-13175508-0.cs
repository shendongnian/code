    public override void Initialize(IComponent component)
    {
       PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(component.GetType());
       PropertyDescriptor descriptor = properties["Visible"];
       if (((descriptor == null) || (descriptor.PropertyType != typeof(bool))) || !descriptor.ShouldSerializeValue(component))
        {
            this.Visible = true;
        }
        else
        {
            this.Visible = (bool) descriptor.GetValue(component);
        }
        ...
     }
