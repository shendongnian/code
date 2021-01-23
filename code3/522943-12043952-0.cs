    public static void ThrowExceptionIfNull(this object argument, string argumentName)
    {
        if(argument == null)
            throw new ArgumentNullException(argumentName);
    } 
