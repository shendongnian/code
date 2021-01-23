    public static T Validate(this T myObj, Func<T, bool> expression)
    {
        if (expression(myObj))
        {
             return myObj; // Return the object for further processing.
        }
        else
        {
             throw new OhNoValidationFailedException("aaaaaaaaahhh!");
        }
    }
