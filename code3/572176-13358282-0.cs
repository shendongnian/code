    Task<string[]> task1 = Task<string[]>.Factory.StartNew(() => GetAllFiles(path));
    // Use this line to throw an exception that is not handled.
    try
    {
        task1.Wait();
    }
    catch (AggregateException ae)
    {
        ae.Handle((x) =>
        {
            if (x is UnauthorizedAccessException) // This we know how to handle.
            {
                Console.WriteLine("You do not have permission to access all folders
                                    in this path.");
                Console.WriteLine("See your network administrator or try
                                    another path.");
                return true;
            }
            return false; // Let anything else stop the application.
        }); 
    }
