    class Tools
    {
        public static String GetMemberName<ObjType, MemberType>(Expression<Func<ObjType, MemberType>> expression)
        {
            MemberExpression member = (MemberExpression)expression.Body;
            return member.Member.Name;
        }
    }
