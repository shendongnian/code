    public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    {
        //Get the base collection of properties
        PropertyDescriptorCollection basePdc = base.GetProperties(context, value, attributes);
        //Create a modifiable copy
        PropertyDescriptorCollection pdc = new PropertyDesctiptorCollection(null);
        foreach (PropertyDescriptor descriptor in basePdc)
            pdc.Add(descriptor);
        //Probably redundant check to see if the value is of a correct type
        if (value is BaseEvent)
            pdc.Add(new FieldDescriptor(typeof(BaseEvent), "BaseProperty"));
        return pdc;
    }
    public class FieldDescriptor : SimplePropertyDescriptor
    {
        //Saves the information of the field we add
        FieldInfo field;
        public FieldDescriptor(Type componentType, string propertyName)
            : base(componentType, propertyName, componentType.GetField(propertyName, BindingFlags.Instance | BindingFlags.NonPublic).FieldType)
        {
            field = componentType.GetField(propertyName, BindingFlags.Instance | BindingFlags.NonPublic);
        }
        public override object GetValue(object component)
        {
            return field.GetValue(component);
        }
        public override void SetValue(object component, object value)
        {
            field.SetValue(component, value);
        }
    }
