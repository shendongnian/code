    using(var p = new Ping())
    {
        try
        {
            var reply = p.Send(host, 3000);
                
            if (reply.Status == IPStatus.Success)
               _lastPingResult = true;
            else  
               _lastPingResult = false; 
        }
        catch(Exception e)
        {
           //...
        }
    }
