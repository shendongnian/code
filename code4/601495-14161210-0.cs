    public int CompareTo( SomeClass other )
    {
        int result = this.SomeProperty.CompareTo( other.SomeProperty );
        if( result != 0 )
            return result;
        result = this.AnotherProperty.CompareTo( other.AnotherProperty );
        if( result != 0 )
            return result;
        [...]
        return result;
    }
