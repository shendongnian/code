    private bool CanPerform(WindowsIdentity identity,
                            string applicationName, int operation,
                            Func<IAzApplication3, IAzClientContext3, bool> predicate)
    {
        IAzApplication3 application = null;
        IAzClientContext3 context = null;
        try
        {
            application = this.store.OpenApplication(applicationName, null) as IAzApplication3;
    
            ulong token = (ulong)identity.Token.ToInt64();
            context = application.InitializeClientContextFromToken(token, null) as IAzClientContext3;
    
            return predicate(application, context);
        }
        catch (COMException e)
        {
            throw new SecurityException(
                string.Format("Unable to check operation '{0}'", operation), e);
        }
        finally
        {
            Marshal.FinalReleaseComObject(context);
            Marshal.FinalReleaseComObject(application);
        }
    }
