    public bool fun(string name)
    {
         bool retry = Properties.Resources.retry == "true";
    
          string result = Get(name);
          if (result == "whatever")
          {
               return true;
           }
           else if (retry)
           {
                Console.WriteLine("Retrying");
                return fun(name);
            }
            return false;
    }
