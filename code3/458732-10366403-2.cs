    public virtual string blabla(long num, out bool bval)
    {
        bool? bvalLocal;
        ... //I'm assuming there is some code here that may or 
            //may not assign bvalLocal?
        // This whole if block may not be needed if the default
        // value is the default for the type (i.e. false) as
        // GetValueOrDefualt() will take care of that (see 
        // second to last line).
        if (!bvalLocal.HasValue)
        {
            //Do some default logic
            bvalLocal = defaultValue;
        }
        
        bval = bvalLocal.GetValueOrDefault();
        return blabla2(num, bval);
    }
