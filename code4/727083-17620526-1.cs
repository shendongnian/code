    asyncDB.BeginExecuteReader(cmd, asyncResult =>
    {
        // Lambda expression executed when the data access completes.
        // ReSharper disable AccessToDisposedClosure
        doneWaitingEvent.Set();
        // ReSharper restore AccessToDisposedClosure
        try
        {
            using (IDataReader reader = asyncDB.EndExecuteReader(asyncResult))
            {
                Console.WriteLine();
                Console.WriteLine();
                DisplayRowValues(reader);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error after data access completed: {0}", ex.Message);
        }
        finally
        {
            // ReSharper disable AccessToDisposedClosure
            readCompleteEvent.Set();
            // ReSharper restore AccessToDisposedClosure
        }
    }, null);
