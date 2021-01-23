     ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
        try
        {
            Console.WriteLine("Returned: {0}", proxy.GetData(-5));
        }
        catch (FaultException<int> faultOfInt)
        {
            //TODO
            proxy.Abort();
        }
        catch (FaultException<string> faultOfString)
        {
            //TODO
            proxy.Abort();
        }
        catch (FaultException<DateTime> faultOfDateTime)
        {
            //TODO
            proxy.Abort();
        }
        catch (FaultException faultEx)
        {
            Console.WriteLine("An unknown exception was received. "
              + faultEx.Message
              + faultEx.StackTrace
            );
            proxy.Abort();
        }
        catch (Exception e)
        {
            //generic method
            Type exceptionType = e.GetType();
            if (exceptionType.IsGenericType && exceptionType.GetGenericTypeDefinition() == typeof(FaultException<>))
            {
                PropertyInfo prop = exceptionType.GetProperty("Detail");
                object propValue = prop.GetValue(e, null);
                Console.WriteLine("Detail: {0}", propValue);
            }
            else
            {
                Console.WriteLine("{0}: {1}", exceptionType, e.Message);
            }
        }
