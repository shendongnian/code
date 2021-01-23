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
    }
