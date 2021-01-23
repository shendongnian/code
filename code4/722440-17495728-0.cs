    void MyMethodName(TimeSpan maxRuntime)
    {
        DateTime expiration = DateTime.Now + maxRuntime;
        for (int i = 0; i <= 90000; i++)
        {
             //validations go here
             if (i % 100 == 0) //  check every 100?
             {
                  if (DateTime.Now > expiration) 
                        break;
             }
        }
    }
