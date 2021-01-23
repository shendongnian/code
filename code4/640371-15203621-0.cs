    public abstract class ExceptionHandler
    {
        /// Returns true if the exception is handled; otherwise returns false.
        public abstract bool Handle(Exception ex);
    
        protected void Log(Exception ex)
        {
            // Log exception here
        }
    }
    
    public class FileExceptionHandler : ExceptionHandler
    {
        public override bool Handle(Exception ex)
        {
            this.Log(ex);
    
            // Tries to handle exceptions gracefully
            if (ex is UnauthorizedAccessException)
            {
                // Add some logic here (for example encapsulate the exception)
                // ...
                return true;
            }
            else if (ex is IOException)
            {
                // Another logic here
                // ...
                return true;
            }
    
            // Did not handled the exception...
            return false;
        }
    }
    
    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                // File manipulation
                throw new IOException();
            }
            catch (Exception ex)
            {
                if (!new FileExceptionHandler().Handle(ex))
                {
                    // Exception not handled, so throw exception
                    throw;
                }
            }
    
            Console.WriteLine("end");
        }
    }
