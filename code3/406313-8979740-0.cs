        Type myType = (typeof(Foo));
        var method = myType.GetMethod("Throws");
        try
        {
            try
            {
                method.Invoke(new Foo(), null);
            }
            catch (AbortTestException ex)
            {
                Console.WriteLine("AbortTestException");
            }
            catch(TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
        }
        catch(AbortTestException ate)
        {
            Console.WriteLine("AbortTestException after re-throw from TargetInvocationException");
        }
