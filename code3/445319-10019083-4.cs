    internal static class MemberInfoWrapperFactory
    {
        public static IMemberInfo CreateWrapper( this MemberInfo memberInfo )
        {
            switch ( memberInfo.MemberType )
            {
                case MemberTypes.Property:
                    return new PropertyInfoWrapper( memberInfo );
                case MemberTypes.Field:
                    return new FieldInfoWrapper( memberInfo );
                default:
                    return null;
            }
        }
    }
