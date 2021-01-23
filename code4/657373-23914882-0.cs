    /// <summary>
    /// Attempts to throw the inner exception of the TargetInvocationException
    /// </summary>
    /// <param name="ex"></param>
    [DebuggerHidden]
    private static void ThrowInnerException(TargetInvocationException ex)
    {
        if (ex.InnerException == null) { throw new NullReferenceException("TargetInvocationException did not contain an InnerException", ex); }
        Exception exception = null;
        try
        {
            //Assume typed Exception has "new (String message, Exception innerException)" signature
            exception = (Exception) Activator.CreateInstance(ex.InnerException.GetType(), ex.InnerException.Message, ex.InnerException);
        }
        catch
        {
            //Constructor doesn't have the right constructor, eat the error and throw the inner exception below
        }
        if (exception == null ||
            exception.InnerException == null ||
            ex.InnerException.Message != exception.Message)
        {
            // Wasn't able to correctly create the new Exception.  Fall back to just throwing the inner exception
            throw ex.InnerException;
        }
        throw exception;
    }
