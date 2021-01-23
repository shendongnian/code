    void YourFun()
    {
        bool connected = false;    
    
        if (isConnected())  //if(isConnected() == true) also doesn't work
        {
              //code
        }
        else {
               connect();
        }
    }
    
    public bool isConnected() {
        if (nextEvent != "null" && !nextEvent.Contains(getEvent("disconnected"))) {
            connected = true;
        }
        return connected;
    }
