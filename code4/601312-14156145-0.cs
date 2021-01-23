    try{ // code that throws exception }
    catch(TypeException ex) 
    { 
        // code to handle exceptions of type TypeException
        // I can access ex parameter, for example to show its Message property
        MessageBox.Show(ex.Message);
    }
    catch(OtherTypeException) 
    { 
        // code to handle exceptions of type OtherTypeException 
        // I cannot access the ex parameter since it is not declared, but I know
        // the exact type of the exception
        MessageBox.Show("There was an exception of Other Type");
    }
    catch
    {
        // code to handle any other exception
        // this is functionally equivalent to catch(Exception) since all typed exceptions
        // inherit from the base type Exception
        MessageBox.Show("An unknown exception has been thrown.");
    }
    ...
