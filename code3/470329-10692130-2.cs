    try
    {
       ///Your code
    }
    catch(Exception exception)
    {
       System.IO.File.WriteAllLines("ErrLog.txt", exception.Message);
    }
