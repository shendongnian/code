    private static T NullValue<T>( object testValue, T nullValue )
    {
        T returnValue;
        if( testValue is DBNull )
        {
            returnValue = nullValue;
        }
        else if( typeof(T).GetGenericTypeDefinition().Equals( typeof(Nullable<>) ) )
        {
            returnValue = (T)Convert.ChangeType( testValue, Nullable.GetUnderlyingType( typeof(T) ) );
        }
        else
        {
            returnValue = (T)Convert.ChangeType( testValue, typeof(T) );
        }
        
        return returnValue;
    }
