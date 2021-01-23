    public override void SomeMethod(params object[] someParams)
    {
        if (someParams[0] == null)
        {
            return;
        }
        // This will throw an exception if you've been given the wrong kind
        // of argument. I prefer that to just silently returning, as it would
        // usually indicate a programming error which should be fixed.
        SomeEnum someEnum = (SomeEnum) someParams[0];
        ...    
    }
