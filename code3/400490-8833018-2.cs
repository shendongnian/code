    var a = new ClassA()
    try
    {
        a.Mehtod1();
    }
    catch
    {
        try
        {
            a.Method1();
        }
        catch (Exception ex)
        {
            //Log without details;
        }
    }
    class ClassA
    {
        void Method1()
        {
            try
            {
                 //Code
            }
            catch (Exception ex)
            {
                //Log with details
                throw;
            }            
        }
    }
