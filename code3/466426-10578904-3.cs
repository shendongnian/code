    try
    {
        myClass.DoSomethingThatCouldThrow();
    }
    catch(InvalidOperationException ex)
    {
        // Do something if it fails...
    }
    try
    {
        myClass.DoSomethingThatCouldThrow();
    }
    catch(InvalidOperationException ex)
    {
        // Do something if it fails...
    }
    try
    {
        myClass.DoAnotherThingWithAThirdExceptionType();
    }
    catch(InvalidOperationException ex)
    {
        // Do something if it fails...
    }
