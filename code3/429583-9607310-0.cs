    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                //This would simulate the event handler that calls your validation event
    
                List<string> errorList = Validation.VerifyData();
    
    
                if (errorList.Count != 0)
                {
                    ErrorHandler.HandleError(errorList);
                    return;
                }
    
                //Do stuff if validation actually passed here.
    
            }
        }
    
        public static class Validation
        {
    
            public static List<string> VerifyData()
            {
                List<string> errorList = new List<string>();
                
                //File exists
                if (true)
                    errorList.Add("File doesn't exist.");
    
                //File has correct extension
                if (true)
                    errorList.Add("File doesn't exist.");
    
                //Has access to the file
                if (true)
                    errorList.Add("File doesn't exist.");
    
                //INput in 2 NumericUpDownControls
                if (true)
                    errorList.Add("File doesn't exist.");
    
                //One NumericUpDown is always greater than the other
                if (true)
                    errorList.Add("File doesn't exist.");
    
                //Assignment to static properties
                if (true)
                    errorList.Add("File doesn't exist.");
    
    
                return errorList;
            }
        }
    
        public static class ErrorHandler
        {
            
            public static void HandleError(List<string> errorMessageList )
            {
                //Display your message here.  This could return a dialog result as well for further processing.
            }
    
        }
    
    
    
    }
