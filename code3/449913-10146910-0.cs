        bool msiIsRunning = false;
        try
        {
            using(var mutex = Mutex.OpenExisting(@"Global\_MSIExecute"))
            {
                msiIsRunning = true;
            }
        }
        catch (Exception)
        {
           // Mutex not found; MSI isn't running
        }
