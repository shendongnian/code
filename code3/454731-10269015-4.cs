    if(Application["someData"] == null) 
    {
        Application.Lock();
        if(Application["someData"] == null) 
        {
            Application["someData"] = getValue(); //a very long time consuming function
        }
        Application.Unlock();
    }
