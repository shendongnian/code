    public class ChildPropertyDescriptor : PropertyDescriptor
    {
    	public static PropertyDescriptor Create(PropertyDescriptor sourceProperty, string childPropertyPath, string displayName = null)
    	{
    		var propertyNames = childPropertyPath.Split('.');
    		var propertyPath = new PropertyDescriptor[1 + propertyNames.Length];
    		propertyPath[0] = sourceProperty;
    		for (int i = 0; i < propertyNames.Length; i++)
    			propertyPath[i + 1] = propertyPath[i].GetChildProperties()[propertyNames[i]];
    		return new ChildPropertyDescriptor(propertyPath, displayName);
    	}
    	private ChildPropertyDescriptor(PropertyDescriptor[] propertyPath, string displayName)
    		: base(propertyPath[0].Name, null)
    	{
    		this.propertyPath = propertyPath;
    		this.displayName = displayName;
    	}
    	private PropertyDescriptor[] propertyPath;
    	private string displayName;
    	private PropertyDescriptor RootProperty { get { return propertyPath[0]; } }
    	private PropertyDescriptor ValueProperty { get { return propertyPath[propertyPath.Length - 1]; } }
    	public override Type ComponentType { get { return RootProperty.ComponentType; } }
    	public override bool IsReadOnly { get { return ValueProperty.IsReadOnly; } }
    	public override Type PropertyType { get { return ValueProperty.PropertyType; } }
    	public override bool CanResetValue(object component) { var target = GetTarget(component); return target != null && ValueProperty.CanResetValue(target); }
    	public override object GetValue(object component) { var target = GetTarget(component); return target != null ? ValueProperty.GetValue(target) : null; }
    	public override void ResetValue(object component) { ValueProperty.ResetValue(GetTarget(component)); }
    	public override void SetValue(object component, object value) { ValueProperty.SetValue(GetTarget(component), value); }
    	public override bool ShouldSerializeValue(object component) { var target = GetTarget(component); return target != null && ValueProperty.ShouldSerializeValue(target); }
    	public override AttributeCollection Attributes { get { return ValueProperty.Attributes; } }
    	public override string Category { get { return ValueProperty.Category; } }
    	public override TypeConverter Converter { get { return ValueProperty.Converter; } }
    	public override string Description { get { return ValueProperty.Description; } }
    	public override bool IsBrowsable { get { return ValueProperty.IsBrowsable; } }
    	public override bool IsLocalizable { get { return ValueProperty.IsLocalizable; } }
    	public override string DisplayName { get { return displayName ?? RootProperty.DisplayName; } }
    	public override object GetEditor(Type editorBaseType) { return ValueProperty.GetEditor(editorBaseType); }
    	public override PropertyDescriptorCollection GetChildProperties(object instance, Attribute[] filter) { return ValueProperty.GetChildProperties(GetTarget(instance), filter); }
    	public override bool SupportsChangeEvents { get { return ValueProperty.SupportsChangeEvents; } }
    	public override void AddValueChanged(object component, EventHandler handler)
    	{
    		var target = GetTarget(component);
    		if (target != null)
    			ValueProperty.AddValueChanged(target, handler);
    	}
    	public override void RemoveValueChanged(object component, EventHandler handler)
    	{
    		var target = GetTarget(component);
    		if (target != null)
    			ValueProperty.RemoveValueChanged(target, handler);
    	}
    	private object GetTarget(object source)
    	{
    		var target = source;
    		for (int i = 0; target != null && target != DBNull.Value && i < propertyPath.Length - 1; i++)
    			target = propertyPath[i].GetValue(target);
    		return target != DBNull.Value ? target : null;
    	}
    }
