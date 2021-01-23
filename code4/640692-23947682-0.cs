    public static Expression<Func<CustomerInfo, bool>> EqualsExpressionTree(  CustomerInfo rhs )
    {
        return ( lhs ) => string.Equals( lhs.Firstname, rhs.Firstname ) &&
                          string.Equals( lhs.Lastname, rhs.Lastname );
    }
