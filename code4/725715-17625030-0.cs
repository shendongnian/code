    public class DisplayNameEnforcingDescriptor : PropertyDescriptor
	{
		private PropertyDescriptor _descriptor;
		public DisplayNameEnforcingDescriptor(PropertyDescriptor descriptor)
			: base(descriptor)
		{
			this._descriptor = descriptor;
		}
		public override string Name
		{
			get
			{
				return string.IsNullOrEmpty(DisplayName) ? base.Name : DisplayName;
			}
		}
		public override bool CanResetValue(object component)
		{
			return _descriptor.CanResetValue(component);
		}
		public override Type ComponentType
		{
			get
			{
				return _descriptor.ComponentType;
			}
		}
		public override object GetValue(object component)
		{
			return _descriptor.GetValue(component);
		}
		public override bool IsReadOnly
		{
			get
			{
				return _descriptor.IsReadOnly;
			}
		}
		public override Type PropertyType
		{
			get
			{
				return _descriptor.PropertyType;
			}
		}
		public override void ResetValue(object component)
		{
			_descriptor.ResetValue(component);
		}
		public override void SetValue(object component, object value)
		{
			_descriptor.SetValue(component, value);
		}
		public override bool ShouldSerializeValue(object component)
		{
			return _descriptor.ShouldSerializeValue(component);
		}
	}
