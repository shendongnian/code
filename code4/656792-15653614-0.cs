    void function() {
        var IsCompleted = false;
        try
        {
            // do something
    
            foreach (item in itemList)
            {
                try 
                {
                    //do something
                }
                catch (Exception ex)
                {
                    throw new Exception("functionB: " + ex.Message);
                }
                var IsCompleted = true;
            }
        }
        catch (Exception ex)
        {
            LogTransaction(ex.Message);
        }
        
        If (!IsCompleted)
           function();
    }
