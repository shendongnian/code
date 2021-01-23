    ISomeInterface interface = this.GetISomeInterfaceInstance();
    
    try
    {
        (interface as ClassImplmentsISomeInterface).Method();
    }
    catch (NullReferenceException)
    {
        interface = this.GetIOtherInterface().Method();
    }
