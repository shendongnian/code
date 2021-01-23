    /// <param name="timeout">how long to keep trying in milliseconds</param>
    static void safeCopy(string src, string dst, int timeout)
    {
        while (timeout > 0)
        {
            try
            {
                File.Copy(src, dst);
                //don't forget to either return from the function or break out fo the while loop
                break;
            }
            catch (IOException)
            {
                //you could do the sleep in here, but its probably a good idea to exit the error handler as soon as possible
            }
            Thread.Sleep(100);
            //if its a very long wait this will acumulate very small errors. 
            //For most things it's probably fine, but if you need precision over a long time span, consider
            //   using some sort of timer or DateTime.Now as a better alternative
            timeout -= 100;
        }
    }
