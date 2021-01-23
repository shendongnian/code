    public static Expression<Func<Person, bool>> EqualsExpressionTree(  Person rhs )
    {
        return ( lhs ) => string.Equals( lhs.Firstname, rhs.Firstname ) &&
                          string.Equals( lhs.Lastname, rhs.Lastname );
    }
