    public void Generate<T>(Operation op) 
        // We assume that there is the keyword "force" to allow only Operation classes
        // to be passed
        where T : force Operation
    { ... }
    public void DoSomething()
    {
        Generate(new BitOperation()); // Will not build
        // "GetOperation" retrieves a Operation class, but at this point you dont
        // know if its "Operation" or not
        Operation op = GetOperation();
        Generate(op); // Will pass
    }
    public Operation GetOperation() { return new BitOperation(); }
