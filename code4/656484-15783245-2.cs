	public static void SetMemberValue(MemberInfo member, object target, object value)
	{
	   switch (member.MemberType)
	   {
		   case MemberTypes.Field:
			   ((FieldInfo)member).SetValue(target, value);
			   break;
		   case MemberTypes.Property:
			   ((PropertyInfo)member).SetValue(target, value, null);
			   break;
		   default:
			   throw new ArgumentException("MemberInfo must be if type FieldInfo or PropertyInfo", "member");
	   }
	}
	
