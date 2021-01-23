    private void TryUntilSuccess(Action action)
    {
        bool success = false;
        while (!success)
        {
            try
            {
                action();
                success = true;
            }
    
            catch (System.Runtime.InteropServices.COMException e)
            {
                if ((e.ErrorCode & 0xFFFF) == 0xC472)
                {   // Excel is busy
                    Thread.Sleep(500); // Wait, and...
                    success = false;  // ...try again
                }
                else
                {   // Re-throw!
                    throw e;
                }
            }
        }
    }
