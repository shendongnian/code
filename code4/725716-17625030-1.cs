    public class DisplayNameEnforcingConverter : ExpandableObjectConverter
	{
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			PropertyDescriptorCollection original = base.GetProperties(context, value, attributes);
			List<DisplayNameEnforcingDescriptor> descriptorList = new List<DisplayNameEnforcingDescriptor>();
			foreach (PropertyDescriptor descriptor in original)
				descriptorList.Add(new DisplayNameEnforcingDescriptor(descriptor));
			return new PropertyDescriptorCollection(descriptorList.ToArray());
		}
	}
