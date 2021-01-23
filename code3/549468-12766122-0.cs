    [__DynamicallyInvokable]
    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }
    
    [__DynamicallyInvokable]
    public static bool operator ==(PropertyInfo left, PropertyInfo right)
    {
        return (object.ReferenceEquals(left, right)
            || ((((left != null) && (right != null)) &&
                 (!(left is RuntimePropertyInfo) && !(right is RuntimePropertyInfo)))
            && left.Equals(right)));
    }
