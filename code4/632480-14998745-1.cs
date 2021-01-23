    bool toggle = false;
    bool exitloop = false;
    int checkinterval = 600; // time in seconds between check
    while(!exitloop)
    {
        bool is_online = check_online();                             
        if (is_online) 
        {
            if (!toggle) 
            {
                Console.WriteLine("Online!" + DateTime.Now.ToString();
                toggle = true;
            }
        }
        else
        {
            if (toggle) 
            {
                Console.WriteLine("Offline!" + DateTime.Now.ToString());
                toggle = false;
            }
        }
        Thread.Sleep(checkinterval * 1000);
        
        // it would be a good idea to allow a mechanism
        // to exit from the infinite loop.
        if (check_if_we_should_exit_loop()) 
        {
            exitloop = true;
        }
    }
