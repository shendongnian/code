    static bool example(int count = 0)
    {
      try
      {
        try
        {
            work();
        }
        catch (TimeoutException e)
        {
            if (count < 3)
            {
                Console.WriteLine("Caught TimeoutException: {0}", e.Message);
                return example(count + 1);
            }
            else
            {
                // Just throw, don't  make a new exception
                throw; //  new Exception(e.Message);
            }
        }
      }
      catch (Exception e)
      {
            Console.WriteLine("Caught Exception: {0}", e.Message + " rethrown");
            return false;
      }
      return true;
    }
