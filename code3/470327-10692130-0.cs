    try
    {
       ///Your code
    }
    catch(Exception exception)
    {
       System.IO.File.WriteAllLines(exception.Message);
    }
