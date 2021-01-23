    public class SpecialContractResolver : DefaultContractResolver
    {
        protected override IValueProvider CreateMemberValueProvider(MemberInfo member)
        {
            if (member.MemberType == MemberTypes.Property)
            {
                var pi = (PropertyInfo)member;
                if (typeof(IValueObject).IsAssignableFrom(pi.PropertyType))
                {
                    return new ExpressionValueProvider(member);
                }
            }
            return base.CreateMemberValueProvider(member);
        }
    }
