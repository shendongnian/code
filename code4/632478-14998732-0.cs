    bool is_online = false;
    for(;;)
    {
        bool check_online = check_online();
        if (check_online != is_online)
        {
            // Online state has changed. Store the new state and log out
            is_online = check_online;
            if (is_online)
            {
                Console.WriteLine("Online !!" +DateTime.Now);
            }
            else
            {
                Console.WriteLine("Offline !!" +DateTime.Now);
            }
        }
    }
