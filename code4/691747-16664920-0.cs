    public class FieldsExpandableObjectConverter : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            List<PropertyDescriptor> properties = new List<PropertyDescriptor>(base.GetProperties(context, value, attributes).OfType<PropertyDescriptor>());
            if (value != null)
            {
                foreach (FieldInfo field in value.GetType().GetFields())
                {
                    FieldPropertyDescriptor fieldDesc = new FieldPropertyDescriptor(field);
                    {
                        properties.Add(fieldDesc);
                    }
                }
            }
            return new PropertyDescriptorCollection(properties.ToArray());
        }
    }
