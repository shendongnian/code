    // Create an instance of the SomeType class that is defined in this 
    // assembly.
    System.Runtime.Remoting.ObjectHandle oh = 
        Activator.CreateInstanceFrom(Assembly.GetEntryAssembly().CodeBase, one + z /* as a  full type name */);
    
    // Call an instance method defined by the SomeType type using this object.
    dynamic st = oh.Unwrap();
    
    st.DoSomething(5);
