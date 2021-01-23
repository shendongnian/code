    public class EnumsByStringName : LoopInjection
    	{
    
    
    		protected override bool MatchTypes(Type source, Type target)
    		{
    			return ((target.IsSubclassOf(typeof(Enum))
    						|| Nullable.GetUnderlyingType(target) != null && Nullable.GetUnderlyingType(target).IsEnum)
    					&& (source.IsSubclassOf(typeof(Enum))
    						|| Nullable.GetUnderlyingType(source) != null && Nullable.GetUnderlyingType(source).IsEnum)
    					);
    		}
    
    		protected override void SetValue(object source, object target, PropertyInfo sp, PropertyInfo tp)
    		{
    			tp.SetValue(target, Enum.Parse(tp.PropertyType, sp.GetValue(source).ToString()));
    		}
    	}
