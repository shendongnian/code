    public static bool IsAny(this object obj, params Type[] types)
    {
    	return types.Contains(obj.GetType());
    }
    
    if(value.IsAny(typeof(SolidColorBrush), typeof(LinearGradientBrush), typeof(GradientBrush), typeof(RadialGradientBrush)))
    {
    }
