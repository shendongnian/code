    for (int i = 0; i < dt.Rows.Count; i++)
    {
        try
        {
            // your existing code goes here
        }
        catch (SomeException ex) // do not catch all exceptions!
        {
            BeginInvoke(...);     // tell the UI thread something bad happened
            pauseEvent.WaitOne(); // and block the worker until user gives input
            if (shouldAbort)
            {
                // cleanup any other resources if required and then
                break;
            }
        }
    }
