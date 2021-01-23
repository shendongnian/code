    public static void SetBinding(this FrameworkElement target, DependencyProperty property, TargetType source, Expression<Func<TargetType, PropertyType>> property_accessor)
    {
      var binding = new Binding(source.PropertyName(property_accessor));
      binding.Source = source;
      target.SetBinding(property, binding);
    }
    public static public string PropertyName(this TargetType obj, Expression<Func> property_accessor)
     { 
    return ((MemberExpression)property_accessor.Body).Member.Name; 
    }
