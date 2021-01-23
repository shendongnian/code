    using System;
    namespace ConsoleApplication2
    {
        class Program
        {
        static void Main(string[] args)
        {
            myException exception;
            try
            {
                throw new ApplicationException("Initial Exception");
            }
            catch (ApplicationException e)
            {
                exception = new myException("Custom Message", e);
            }
            catch (Exception e)
            {
                throw e;
            }
            if (exception != null)
            {
                throw exception;
            }
        }
    }
    }
    public class myException : ApplicationException
    {
    public myException(string msg, ApplicationException e) : base(msg, e) { }
    }
