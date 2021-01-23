    var background = new Thread(() =>
    {
         var proxy = new AssignmentSvcProxy(new EndpointAddress(worker.Address));              
        try
        {
            proxy.Channel.StartWork(workload);
        }
        catch (Exception ex)
        {
            // You aren't doing anything special with your specific exception types
            logService.Error(ex);                    
        }                
        finally
        {
        	try
            {
        		proxy.Close();
        	}
            catch (Exception ex)
            {
                proxy.Abort();
            }
            finally
            {
        		proxy = null;
        	}
        }
    }) { IsBackground = true };
    background.Start();
