    do
    {
        try
        {
            var input = Console.ReadLine();
            var myNumber = Int32.Parse(input);
            DoSomethingWithNumber(myNumber);
            break;
        }
        catch(Exception e)
        {
            // Optional error handling, explain the error,
            // tell the user to retry, logging, etc.
            // If possible, catch something more specific
            // than Exception (like ArgumentException, 
            // FormatException, etc.).
        }
    } while(true);
