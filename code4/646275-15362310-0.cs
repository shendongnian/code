    if(Monitor.TryEnter(this, 500))
    {
        // critical section
    }
    catch (Exception ex)
    {
     
    }
    finally
    {
        Monitor.Exit();
    }
