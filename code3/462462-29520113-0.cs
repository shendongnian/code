    using (var client = new SmtpClient(_serverCfg.Host, _serverCfg.Port)) 
    {        
        try
        {
            client.Timeout = 5000;   // shorter timeout than the task.Wait()
            // ...
            client.Send(msg);
        }
        catch (Exception ex)
        {
            // exception handling
        }
    }
