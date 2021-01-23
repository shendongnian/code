    void waitclientconnection()
    {
        if (clientOne is connected)
        {    
             startserver(); //create new thread to wait connection for next client
        }
    
        while (keepGoing)
        {
            ...
    
            if (clientOne sends "close" message)
            {
                 keepGoing = false;
            }
        }
    }
